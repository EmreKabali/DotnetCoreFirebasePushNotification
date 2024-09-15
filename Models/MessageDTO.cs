using System;

namespace DotnetCoreFirebasePushNotification.Models;

public class MessageDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public string? UserTokenId { get; set; }
    public string? Topic { get; set; }
}
