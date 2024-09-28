from abc import ABC, abstractmethod
# from ..factory.factory_main import (
#     Konny, Piechur, Strzelec
# )

class Wojownik(ABC):
    def __str__(self) -> str:
        return f"Jestem wojownikiem. \
            Moja profesja to {self.__class__.__name__}"
    
class Piechur(Wojownik):
    pass

class Strzelec(Wojownik):
    pass

class Konny(Wojownik):
    pass


class WarriorBuilder(ABC):
    @abstractmethod
    def join_army(self):
        pass

    @abstractmethod
    def get_weapon(self):
        pass

    @abstractmethod
    def train_fight(self):
        pass


class BaseBuilder(WarriorBuilder):
    def join_army(self):
        print("I have joined the army")
        return self

    def get_weapon(self):
        print("I got a weapon!")
        return self
    
    def train_fight(self):
        print("I was trained in fight")
        return self


class PiechurBuilder(BaseBuilder):
    def join_army(self):
        print("I have joined the army - chodze sobie pieszo")
        return self

    def get_weapon(self):
        print("I got a weapon! - miecz :)")
        return self

    def train_fight(self):
        print("I was trained to run fast!")
        return self


class StrzeleBuilder(BaseBuilder):
    def join_army(self):
        print("I have joined the army - chodze sobie pieszo i strzelam")
        return self
    
    def get_weapon(self):
        print("I got another weapon - special for Strzelec!")
        return self

    def train_fight(self):
        print("I was trained in fight as strzelec")
        return self


class KonnyBuilder(BaseBuilder):
    def join_army(self):
        print("I have joined the army - mam konia")
        return self

    def get_weapon(self):
        print("I got a weapon! - KON")
        return self

    def train_fight(self):
        print("I was trained in fight on horse!")
        return self


class GarnizonBuilder:
    @staticmethod
    def train_warrior(warrior_builder: WarriorBuilder) -> WarriorBuilder:
        builder_classes = {
            Piechur: PiechurBuilder,
            Strzelec: StrzeleBuilder,
            Konny: KonnyBuilder
        }
        
        # uzywam mapowania ktore pozwala mi zastapic multi if statement
        builder = builder_classes.get(type(warrior_builder))()
        return (
            builder
                .join_army()
                .get_weapon()
                .train_fight()
        )


if __name__ == "__main__":
    # to be executed using command 'python <relative_path>/factory/factory_main.py
    garnizon = GarnizonBuilder()

    print("Trenowanie piechura")
    trained_piechur = garnizon.train_warrior(Piechur())

    print("Trenowanie strzelca")
    trained_strzelec = garnizon.train_warrior(Strzelec())

    print("Trenowanie konnicy")
    trained_konny = garnizon.train_warrior(Konny())