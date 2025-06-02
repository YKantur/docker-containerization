FROM python:3.10-bullseye

WORKDIR /app

RUN apt-get update && apt-get install -y --no-install-recommends \
    && rm -rf /var/lib/apt/lists/*

COPY requirements.txt .

RUN pip install --no-cache-dir --upgrade pip && \
    pip install --no-cache-dir -r requirements.txt

COPY build/ build/

COPY spaceship/config.py spaceship/config.py
COPY spaceship/__init__.py spaceship/__init__.py

COPY spaceship/routers/ spaceship/routers/

COPY spaceship/main.py spaceship/main.py
COPY spaceship/app.py spaceship/app.py

EXPOSE 8000

CMD ["uvicorn", "spaceship.main:app", "--host", "0.0.0.0", "--port", "8000"]