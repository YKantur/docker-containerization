from spaceship.app import make_app
from spaceship.config import Settings

app = make_app(Settings())

# This is the entry point for the FastAPI application.