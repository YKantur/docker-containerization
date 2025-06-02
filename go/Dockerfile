FROM golang:1.22 AS builder

WORKDIR /app

COPY go.mod go.sum ./
RUN go mod download

COPY . .

RUN CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o fizzbuzz .

FROM scratch

COPY --from=builder /app/fizzbuzz /fizzbuzz

EXPOSE 8080

CMD ["/fizzbuzz", "serve", "--port", "8080"]