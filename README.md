# MockRetailerApi

Mock Retailer API built using ASP.NET Core .NET 8 Web API.

Features:

* Generate OTP
* Check OTP
* Register Retailer
* Fetch Business Details
* In-memory mock data
* Swagger support
* Header validation middleware
* No database required

---

# Tech Stack

* .NET 8
* ASP.NET Core Web API
* Swagger
* In-Memory Object Store

---

# Project Structure

```text
MockRetailerApi
│
├── Controllers
│   └── RetailerController.cs
│
├── Models
│   ├── Requests
│   │   ├── GenerateOtpRequest.cs
│   │   ├── CheckOtpRequest.cs
│   │   ├── RegisterRetailerRequest.cs
│   │   └── BusinessDetailsRequest.cs
│   │
│   └── Entities
│       └── OtpStore.cs
│
├── MockData
│   └── MockRetailerData.cs
│
├── Middleware
│   └── ApiHeaderMiddleware.cs
│
├── Program.cs
│
└── MockRetailerApi.csproj
```

---

# Create Project

```bash
dotnet new webapi -n MockRetailerApi
```

---

# Install Swagger

```bash
dotnet add package Swashbuckle.AspNetCore
```

---

# Run Project

```bash
dotnet run
```

---

# Swagger URL

```text
https://localhost:7118/swagger
```

---

# Required Headers

## x-api-key

```text
Basic V2swRVFLQ2RaY3JibjBFOnY5VGtEbjhScGxw
```

## authorization

```text
bearer testtoken
```

---

# Mock OTP Test Data

| Mobile     | OTP    | Token     |
| ---------- | ------ | --------- |
| 8446152135 | 179237 | TOKEN_001 |
| 7208505572 | 316243 | TOKEN_002 |
| 9819631954 | 654321 | TOKEN_003 |
| 9988776655 | 111111 | TOKEN_004 |

---

# APIs

---

# 1. Generate OTP

## Endpoint

```http
POST /register/retailer/validatemobile/generate_otp
```

## CURL

```bash
curl --location 'https://localhost:7118/register/retailer/validatemobile/generate_otp' \
--header 'x-api-key: Basic V2swRVFLQ2RaY3JibjBFOnY5VGtEbjhScGxw' \
--header 'authorization: bearer testtoken' \
--header 'Content-Type: application/json' \
--data '{
    "username":"8446152135",
    "version":"13"
}'
```

## Request Body

```json
{
  "username": "8446152135",
  "version": "13"
}
```

## Success Response

```json
{
  "resultCode": "200",
  "resultStatus": "TXN",
  "resultMessage": "Verification code has been send to mobile number 8446152135",
  "otpToken": "TOKEN_001"
}
```

---

# 2. Check OTP

## Endpoint

```http
POST /register/retailer/validatemobile/check_otp
```

## CURL

```bash
curl --location 'https://localhost:7118/register/retailer/validatemobile/check_otp' \
--header 'x-api-key: Basic V2swRVFLQ2RaY3JibjBFOnY5VGtEbjhScGxw' \
--header 'authorization: bearer testtoken' \
--header 'Content-Type: application/json' \
--data '{
    "otp":"179237",
    "otpToken":"TOKEN_001"
}'
```

## Request Body

```json
{
  "otp": "179237",
  "otpToken": "TOKEN_001"
}
```

## Success Response

```json
{
  "resultCode": "200",
  "resultStatus": "TXN",
  "otpToken": "NEW_TOKEN",
  "resultMessage": "Details not found"
}
```

## Error Response

```json
{
  "resultCode": "400",
  "resultStatus": "ERR",
  "resultMessage": "In-valid Otp."
}
```

---

# 3. Register Retailer

## Endpoint

```http
POST /register/retailer/new
```

## CURL

```bash
curl --location 'https://localhost:7118/register/retailer/new' \
--header 'x-api-key: Basic V2swRVFLQ2RaY3JibjBFOnY5VGtEbjhScGxw' \
--header 'authorization: bearer testtoken' \
--header 'Content-Type: application/json' \
--data '{
  "CompanyType": 2,
  "businessServiceType": "2",
  "email": "saurabh@gmail.com",
  "firstName": "Saurabh",
  "lastName": "Panday",
  "mobileNo": "7208505572",
  "otp": "179237",
  "otpToken": "TOKEN_001",
  "pincode": "400055"
}'
```

## Request Body

```json
{
  "CompanyType": 2,
  "businessServiceType": "2",
  "email": "saurabh@gmail.com",
  "firstName": "Saurabh",
  "lastName": "Panday",
  "mobileNo": "7208505572",
  "otp": "179237",
  "otpToken": "TOKEN_001",
  "pincode": "400055"
}
```

## Success Response

```json
{
  "status": "true",
  "data": "Details found.",
  "businessIdentificationCode": "876fb243",
  "businessName": "NA",
  "businessOwnerName": "Saurabh Panday",
  "mobile": "7208505572",
  "businessStatus": "IN COMPLETE",
  "isKycOfficer": 0,
  "companyType": 2,
  "businessServiceType": "2",
  "balance": "0",
  "businessAuthToken": "sample-token",
  "resultMessage": "Retailer Registered Successfully",
  "resultCode": "200",
  "resultStatus": "TXN"
}
```

## Error Response

```json
{
  "resultCode": "400",
  "resultStatus": "ERR",
  "resultMessage": "Invalid OTP"
}
```

---

# 4. Business Details Fetch

## Endpoint

```http
POST /retailer/businessdetailsFetchnew
```

## CURL

```bash
curl --location 'https://localhost:7118/retailer/businessdetailsFetchnew' \
--header 'x-api-key: Basic V2swRVFLQ2RaY3JibjBFOnY5VGtEbjhScGxw' \
--header 'authorization: bearer testtoken' \
--header 'Content-Type: application/json' \
--data '{
    "BusinessId":"0",
    "IdentificationCode":"2b91a674"
}'
```

## Request Body

```json
{
  "BusinessId": "0",
  "IdentificationCode": "2b91a674"
}
```

## Success Response

```json
{
  "status": "true",
  "data": "Details found.",
  "businessIdentificationCode": "2b91a674",
  "businessName": "Nikhil Enterprise",
  "businessOwnerName": "Nikhil Nishad",
  "mobile": "9819631954",
  "businessStatus": "IN COMPLETE",
  "isKycOfficer": 0,
  "companyType": 2,
  "businessServiceType": "2",
  "balance": "0",
  "resultMessage": "Details found.",
  "resultCode": "200",
  "resultStatus": "TXN"
}
```

---

# Common Error Responses

## Invalid API Key

```json
{
  "resultCode": "401",
  "resultStatus": "ERR",
  "resultMessage": "Invalid x-api-key"
}
```

## Invalid Authorization Header

```json
{
  "resultCode": "401",
  "resultStatus": "ERR",
  "resultMessage": "Invalid authorization token"
}
```

---

# Notes

* This project uses in-memory objects only.
* No database integration.
* OTP validation is mocked.
* Swagger is enabled.
* APIs are intended for testing and development.
* You can extend this with:

  * xUnit Testing
  * Docker
  * FluentValidation
  * Serilog
  * Correlation ID Middleware
  * JWT Validation
  * Repository Pattern
  * Service Layer
