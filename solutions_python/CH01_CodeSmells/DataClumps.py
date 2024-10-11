from datetime import datetime
from dataclasses import dataclass
from typing import overload
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

# not updated function
@overload  
def register_event(event_name: str,
                   event_date: datetime,
                   location: str) -> str:
    return (
        f"Event: {event_name}, 
        Date: {event_date}, 
        Location: {location}"
    )

# updated funtion
@overload
def register_event(event_details: EventDetails) -> str:
    return (
        f"Event: {event_details.event_name}, 
        Date: {event_details.event_date}, 
        Location: {event_details.location}"
    )