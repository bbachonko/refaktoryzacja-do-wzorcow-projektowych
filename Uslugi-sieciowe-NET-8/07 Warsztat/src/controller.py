from typing import List
from fastapi import FastAPI, HTTPException, Depends, status
from sqlalchemy.ext.asyncio import AsyncSession
from models import Post
from ef_core_repository import AsyncSessionLocal
from interfaces import IRepository


app = FastAPI()

# Dependency to provide an async SQLAlchemy session
async def get_session() -> AsyncSession:
    async with AsyncSessionLocal() as session:
        yield session

# Dependency to create a IRepository for Post using the session
async def get_post_repository(
    session: AsyncSession = Depends(get_session)
) -> IRepository[Post]:
    return IRepository[Post](session, Post)

@app.get("/posts", response_model=List[Post])
async def get_all_posts(
    repo: IRepository[Post] = Depends(get_post_repository)):
    posts = await repo.get_all_async()
    return posts

@app.get("/posts/{id}", response_model=Post)
async def get_post_by_id(id: int, repo: IRepository[Post] = Depends(get_post_repository)):
    post = await repo.get_by_id_async(id)
    if post is None:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Post not found")
    return post

@app.post("/posts", response_model=Post, status_code=status.HTTP_201_CREATED)
async def create_post(post: Post, repo: IRepository[Post] = Depends(get_post_repository)):
    # Here we assume add_async sets an ID on the post or returns an identifier.
    await repo.add_async(post)
    return post

@app.put("/posts/{id}", status_code=status.HTTP_204_NO_CONTENT)
async def update_post(
    id: int, 
    post: Post, 
    repo: IRepository[Post] = Depends(get_post_repository)
):
    if id != post.id:
        raise HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail="ID mismatch")

    # Assuming update_async returns a boolean indicating success
    success = await repo.update_async(post)
    if not success:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Post not found")
    return

@app.delete("/posts/{id}", status_code=status.HTTP_204_NO_CONTENT)
async def delete_post(id: int, repo: IRepository[Post] = Depends(get_post_repository)):
    # First retrieve the post by id
    post = await repo.get_by_id_async(id)
    if not post:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Post not found")

    # Assuming delete_async can accept an entity and returns a success boolean
    success = await repo.delete_async(post)
    if not success:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail="Post not found")
    return
