from sqlalchemy.ext.asyncio import create_async_engine, AsyncSession
from sqlalchemy.orm import sessionmaker
from models import Post
from interfaces import IRepository
from datetime import datetime
import asyncio


engine = create_async_engine("postgresql+asyncpg://user:password@localhost/dbname")
AsyncSessionLocal = sessionmaker(engine, expire_on_commit=False, class_=AsyncSession)


async def main():
    async with AsyncSessionLocal() as session:
        repo = IRepository[Post](session, Post)
        
        # Add a new entity
        new_entity = Post(
            Content="test content",
            ImageUrl="test url",
            Published=datetime(2000, 10, 1)
        )  # fill with appropriate fields
        await repo.add_async(new_entity)
        
        # Retrieve all entities
        all_entities = await repo.get_all_async()
        
        # Get entity by id
        entity = await repo.get_by_id_async(1)
        
        # Update entity
        if entity:
            entity.Title = "test title"
            await repo.update_async(entity)
        
        # Delete entity
        if entity:
            await repo.delete_async(entity)


if __name__ == "__main__":
    import asyncio
    asyncio.run(main())
