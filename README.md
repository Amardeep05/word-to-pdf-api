# Word to PDF Converter API (.NET) 🚀

A portfolio project built with **ASP.NET Core Web API** that converts **Word documents (.doc/.docx) into PDF files** using **API Versioning**.

This project demonstrates how to handle **different file sizes with different conversion strategies** for better performance and scalability.

---

## 📌 Project Overview

This API provides **two versioned endpoints** for converting Word files into PDF:

* **API v1.0 → GemBox.Document**

  * Best for **small/lightweight Word files (~25 KB)**
  * Faster and lightweight processing
  * Ideal for simple portfolio demo use cases

* **API v2.0 → Syncfusion DocIO**

  * Best for **large Word files**
  * Better handling for complex formatting and bigger documents
  * Suitable for heavy document processing scenarios

---

## 🏗️ Tech Stack

* **ASP.NET Core Web API**
* **C#**
* **API Versioning**
* **GemBox.Document**
* **Syncfusion DocIO + PDF Renderer**
* **Swagger / OpenAPI**

---

## 🔀 API Versioning Strategy

This project uses **URL-based API versioning**.

### Version 1.0 – Small Files

```csharp
[ApiVersion("1.0")] // GemBox version for small files
```

### Version 2.0 – Large Files

```csharp
[ApiVersion("2.0")] // Syncfusion version for large files
```

---

## 📂 Use Cases

### ✅ v1.0 – Small Word Files

Use this version when:

* File size is around **25 KB**
* Simple formatting
* Faster response required

### ✅ v2.0 – Large Word Files

Use this version when:

* File size is **large**
* Heavy tables/images/complex formatting
* Better rendering accuracy is needed

---

## ⚠️ Important Note About Watermark in v2.0

> **Portfolio / Testing Notice:**
> API version **v2.0 uses the Syncfusion trial library for testing and demonstration purposes only**.
> Because of the **trial version license**, generated PDF files may show a **watermark message** such as:
> *"Created with a trial version of Syncfusion PDF library"*.
>
> This is **expected behavior in the testing environment** and does **not affect the actual conversion logic**.
>
> In a production-ready implementation, this watermark can be removed by using a **valid licensed Syncfusion key**.

---

## 🎯 Why I Built This

This project is part of my **GitHub portfolio** to showcase:

* Clean API design
* API versioning best practices
* Third-party document libraries integration
* Handling different performance strategies
* Real-world file conversion use cases

---

## 🚀 Future Improvements

* Add **async/await optimization**
* Azure Blob Storage support
* Queue-based large file processing
* Background jobs with Hangfire
* Authentication & rate limiting
* Docker deployment

---

## 👨‍💻 Author

**Amardeep Singh**
Software Engineer | .NET Developer | Web API Enthusiast

---

## ⭐ GitHub Portfolio Note

This repository is created for **learning, demonstration, and portfolio purposes**.
It highlights how **different API versions can solve the same business problem with optimized strategies**.
