﻿namespace JungleCafe.Server.DTOs;

public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? MaxParticipants { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPublic { get; set; }
    public CreatorDto Creator { get; set; } = null!;
}