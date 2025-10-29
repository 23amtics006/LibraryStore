## 📚 LibraryStore - Smart Book Management System

---

### Description

LibraryStore is a web-based **Smart Book Management System** built with **ASP.NET Core** and an **SQLite** database. It provides an intuitive platform for managing a library's book inventory, user accounts, and borrowing records.

**Key Features:**

* **User Authentication & Authorization:** Supports separate roles for **Admin** and **User**.
    * **Admin (`admin@librarystore.com`):** Can manage books (Add, Edit, Delete), view all user accounts, and see all borrow/return records.
    * **User (e.g., om kavani):** Can register, log in, browse available books, **Borrow** books, and **Return** books via the "My Books" section.
* **Book Management:** Admins can add new books with details like Title, Author, and Genre. The database currently holds 27 books (e.g., "Clean Code", "Deep Learning").
* **Borrowing Records:** The system tracks which books are **Borrowed** (Return Date is NULL in DB, Status is 'Borrowed' in UI) and which have been **Returned** (Return Date present, Status is 'Returned' in UI).
* **Dashboard Overview:** An Admin Dashboard provides a quick summary: **3 Users**, **25 Books** (likely 2 were marked as test entries or deleted), and **4 Currently Borrowed** books.
* **Database:** Uses **SQLite** for data persistence, managed through Entity Framework Core. Key tables include `Users`, `Books`, and `BorrowRecords`.

---

### Installation Steps

To set up and run this .NET Core project, you will need the following prerequisites installed on your system:

1.  **[.NET SDK](https://dotnet.microsoft.com/download):** Install the appropriate .NET SDK version (the project appears to use a modern version, likely .NET 6 or higher).
2.  **Code Editor:** A suitable editor such as **Visual Studio** or **Visual Studio Code** with the C# Dev Kit extension.
3.  **Database:** The project uses **SQLite**. Ensure you have the project's SQLite database file (e.g., `LibraryStore.sqlite`) present in the project directory.

#### Project Setup

1.  **Clone or Download:** Get the entire project folder onto your local machine.
2.  **Restore Dependencies:** Navigate to the main project folder (where the `.csproj` file is located) in your terminal and run the following command to restore necessary NuGet packages:

    ```bash
    dotnet restore
    ```

3.  **Database Migration (If needed):** If the database file is not pre-seeded, you may need to apply migrations to create the schema.

    ```bash
    # Only if the database schema is missing
    dotnet ef database update
    ```

---

### How to Run the Project

You can run the project using the **.NET CLI (Command Line Interface)** or through a full IDE like **Visual Studio**.

#### Option 1: Using the .NET CLI

1.  **Open Terminal:** Navigate to the main project directory (the one containing the `.csproj` file).
2.  **Run the Application:** Execute the following command:

    ```bash
    dotnet run
    ```
    *This command will automatically build the project and then start the web server.*
3.  **Access the Application:** The terminal will display the local URL (e.g., `http://localhost:5132`). Open your web browser and navigate to this URL.

#### Option 2: Using Visual Studio / Visual Studio Code

1.  **Open Project:** Open the solution file (`.sln`) in Visual Studio or open the project folder in Visual Studio Code.
2.  **Start Debugging:**
    * In **Visual Studio**, press the **F5** key or click the **Start Debugging** button.
    * In **Visual Studio Code**, open the Run and Debug view, select the appropriate launch configuration, and click the **Start Debugging** button.
3.  **Access the Application:** Your default web browser will typically open automatically to the application's home page. 