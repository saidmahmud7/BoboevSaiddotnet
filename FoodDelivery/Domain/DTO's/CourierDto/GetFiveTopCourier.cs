﻿using Domain.Enum;

namespace Domain.DTO_s.CourierDto;

public class GetFiveTopCourier
{
    public int Id { get; set; }
    public CourierStatus Status { get; set; }
    public string CurrentLocation { get; set; }
    public decimal Rating { get; set; }
    public TransportType TransportType { get; set; }
    public int UserId { get; set; }
}