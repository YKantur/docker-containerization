FROM python:3.10-alpine as builder

RUN apk add --no-cache gcc musl-dev linux-headers

COPY requirements.txt .
RUN pip install --user --no-cache-dir -r requirements.txt

FROM python:3.10-alpine

WORKDIR /app

COPY --from=builder /root/.local /root/.local

ENV PATH=/root/.local/bin:$PATH

COPY build/ build/

COPY spaceship/config.py spaceship/config.py
COPY spaceship/__init__.py spaceship/__init__.py

COPY spaceship/routers/ spaceship/routers/

COPY spaceship/main.py spaceship/main.py
COPY spaceship/app.py spaceship/app.py

EXPOSE 8000

CMD ["uvicorn", "spaceship.main:app", "--host", "0.0.0.0", "--port", "8000"]