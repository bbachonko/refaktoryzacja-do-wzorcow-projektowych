class Cylinder:
    @staticmethod
    def get_size() -> str:
        return "2.0L"

class Engine:
    @staticmethod
    def get_cylinder() -> Cylinder:
        return Cylinder
    
class Car:
    @staticmethod        
    def get_cylinder_size(engine: Engine):
        return (
            engine
            .get_cylinder()
            .get_size()
        )
    

if __name__ == "__main__":
    car = Car()
    cylinder_size = (
        car.get_cylinder_size(engine=Engine())
    )
    print(cylinder_size)