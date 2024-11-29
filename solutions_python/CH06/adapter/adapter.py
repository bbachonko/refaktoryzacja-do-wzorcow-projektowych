from dataclasses import dataclass

@dataclass
class Adult:
    name: str
    age: int


@dataclass
class FakeAdult(Adult):
    def __post_init__(self):
        if self.age < 18:
            self.age = 18
    
class Bouncer:
    """Class that has passed a class with person and decides whether to let her pass."""
    def __init__(self, person: Adult):
        self._check_maturity(person)
        
    def _check_maturity(self, person):
        return (
            print("Person has passed the check!") if person.age >= 18 
            else print("Person is not 18 yrs old yet!")
        )


if __name__ == "__main__":
    adult1 = Adult(name="Alice", age=30)
    adult2 = Adult(name="Bob", age=17)

    fake_adult1 = FakeAdult(name="Charlie", age=25)
    fake_adult2 = FakeAdult(name="Diana", age=16)

    print(adult1)
    print(adult2)
    print(fake_adult1)
    print(fake_adult2)
    
    assert fake_adult1.age == fake_adult1.age
    assert fake_adult2.age == 18
    
    bouncer = Bouncer(adult1)
    bouncer2 = Bouncer(adult2)
        
    