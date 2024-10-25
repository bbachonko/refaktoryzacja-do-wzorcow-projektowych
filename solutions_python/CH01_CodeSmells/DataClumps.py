from datetime import datetime
from dataclasses import dataclass
""" csharp
public void RegisterEvent(string eventName, DateTime eventDate, string location)
{
    Console.WriteLine($"Event: {eventName}, Date: {eventDate}, Location: {location}");
}
"""
# dataclass representing event details
@dataclass
class EventDetails:
    event_name: str
    event_date: datetime
    location: str


def register_event(event: EventDetails) -> str:
    return (
        f"Event: {event.event_name}"
        f"Date: {event.event_date}"
        f"Location: {event.location}"
    )


