from abc import ABC, abstractmethod
from typing import Generic, TypeVar, List, Optional


T = TypeVar('T')

class IRepository(ABC, Generic[T]):
    @abstractmethod
    async def get_all_async(self) -> List[T]:
        """Asynchronously retrieves all objects of type T."""
        pass

    @abstractmethod
    async def get_by_id_async(self, id: int) -> Optional[T]:
        """Asynchronously retrieves an object of type T by its identifier."""
        pass

    @abstractmethod
    async def add_async(self, entity: T) -> int:
        """Asynchronously adds a new object of type T and returns its identifier."""
        pass

    @abstractmethod
    async def update_async(self, entity: T) -> bool:
        """Asynchronously updates an object of type T and returns the success status."""
        pass

    @abstractmethod
    async def delete_async(self, id: int) -> bool:
        """Asynchronously deletes an object of type T by its identifier and returns the success status."""
        pass
