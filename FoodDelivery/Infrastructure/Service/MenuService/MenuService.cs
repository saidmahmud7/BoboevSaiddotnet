﻿using System.Net;
using AutoMapper;
using Domain.DTO_s.MenuDto;
using Domain.DTO_s.OrderDto;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.MenuService;

public class MenuService(DataContext context, IMapper mapper) : IMenuService
{
    public async Task<PaginationResponse<List<GetMenuDto>>> GetAll(MenuFilter filter)
    {
        IQueryable<Menu> menus = context.Menus;
        if (!string.IsNullOrEmpty(filter.Name))
            menus = menus.Where(m => m.Name.ToLower().Contains(filter.Name.ToLower()));
        if (!string.IsNullOrEmpty(filter.Category))
            menus = menus.Where(m => m.Category.ToLower().Contains(filter.Category.ToLower()));
        if (filter.PreparationTime.HasValue) 
            menus = menus.Where(m=>m.PreparationTime == filter.PreparationTime);
        if (filter.Weight.HasValue)
            menus = menus.Where(m => m.Weight == filter.Weight);
        if (filter.Price.HasValue)
            menus = menus.Where(m => m.Price == filter.Price);
        if (filter.RestaurantId.HasValue)
            menus = menus.Where(m=>m.RestaurantId == filter.RestaurantId);
        int total = await menus.CountAsync();
        var result = menus.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x=>mapper.Map<GetMenuDto>(x))
            .ToList();
        return new PaginationResponse<List<GetMenuDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetMenuDto>> GetById(int id)
    {
        var menu = await context.Menus.FirstOrDefaultAsync(x => x.Id == id);
        var menuDto = mapper.Map<GetMenuDto>(menu);
        return new ApiResponse<GetMenuDto>(menuDto);
    }

    public async Task<ApiResponse<string>> CreateMenu(CreateMenuDto menu)
    {
        var menus = mapper.Map<Menu>(menu);
        context.Menus.Add(menus);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Menu created");
    }

    public async Task<ApiResponse<string>> UpdateMenu(UpdateMenuDto menu)
    {
        var existingMenu = await context.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id);
        if (existingMenu == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Menu not found");
        }

        existingMenu.Name = menu.Name;
        existingMenu.Description = menu.Description;
        existingMenu.Price = menu.Price;
        existingMenu.Category = menu.Category;
        existingMenu.IsAvailable = menu.IsAvailable;
        existingMenu.PreparationTime = menu.PreparationTime;
        existingMenu.Weight = menu.Weight;
        existingMenu.PhotoUrl = menu.PhotoUrl;
        existingMenu.RestaurantId = menu.RestaurantId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Menu updated");
    }

    public async Task<ApiResponse<string>> DeleteMenu(int id)
    {
        var existingMenu = await context.Menus.FirstOrDefaultAsync(x => x.Id == id);
        if (existingMenu == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Menu not found");
        }

        context.Remove(existingMenu);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Menu deleted");
    }

    public async Task<ApiResponse<List<GetMenuDto>>> Task2()
    {
        var x = context.Menus
            .Include(m=>m.Restaurant)
            .Where(m=>m.Price<1000).AsQueryable();
        var menus = mapper.Map<List<GetMenuDto>>(x);
        return new ApiResponse<List<GetMenuDto>>(menus);
    }

    public async Task<ApiResponse<List<GetAvarageByCategory>>> Task4()
    {
        var menus = context.Menus.AsQueryable();
        var res = await menus
            .GroupBy(x => x.Category)
            .Select(g => new GetAvarageByCategory
            {
                Category = g.Key,
                Price = g.Average(p => p.Price)
            })
            .ToListAsync();

        return new ApiResponse<List<GetAvarageByCategory>>(res);
    }

    public async Task<ApiResponse<GetCategoryWithCountOfFood>> Task10()
    {
        var menus = context.Menus.AsQueryable();
        var res = menus.GroupBy(x => x.Category).Select(g => new GetCategoryWithCountOfFood()
        {
            Category = g.Key,
            Count = g.Count()
        }).OrderByDescending(x=>x.Count).Take(1).ToListAsync();
        var result = mapper.Map<GetCategoryWithCountOfFood>(res);
        return new ApiResponse<GetCategoryWithCountOfFood>(result);
    }
    
}