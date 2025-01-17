from pydantic import BaseModel
from datetime import datetime


class Post(BaseModel):
    Title: str
    Content: str
    ImageUrl: str
    Published: datetime