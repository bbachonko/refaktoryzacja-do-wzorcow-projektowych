from abc import ABC, abstractmethod, a 

"""
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public void Work() { /* Implementacja */ }
    public void AttendMeeting() { /* Implementacja */ }
}

public class Manager : Employee
{
    public void ManageTeam() { /* Implementacja */ }
}
"""

class IEmployee(ABC):
    @staticmethod
    @abstractmethod
    def work():
        pass

    @staticmethod
    @abstractmethod
    def attend_meeting():
        pass

class Manager(IEmployee):
    name: str = None
    position: str = None

    @staticmethod
    def manage_team():
        print("i'd like to have it implement but dont have time")



