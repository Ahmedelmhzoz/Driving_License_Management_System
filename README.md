# 🚗 Driving & Vehicle License Department (DVLD) System

A desktop application designed to digitize and automate the lifecycle of driving licenses, applicant testing workflows, and license management for the Driving & Vehicle License Department (DVLD). Built using **C#**, **.NET WinForms**, and **SQL Server**, following a strict **3-Tier Architecture** (Presentation, Business Logic, Data Access Layers) to ensure maintainability, scalability, and security.

---

## 🌟 Key Features & Business Modules

### 1. 🪪 License Issuance & Management

* **First-Time License Issuance:** Handles initial applications, class selection, age verification, and prerequisite checking.


* **License Renewals:** Manages license expiration, mandatory vision checks, and old license submission requirements.


* **Replacements (Lost / Damaged):** Issues replacement licenses while verifying non-detained status.


* **International Licenses:** Validates Class 3 (Ordinary) eligibility and issues international driving permits.


* **Detain & Release System:** Supports detaining licenses with fine management and tracking release authorization.



### 2. 📝 Sequential Testing Workflow Engine

Processes applicants through a strict 3-stage testing workflow:

1. **Vision Test:** Medical visual fitness check.


2. **Theoretical (Written) Test:** Traffic law and safety rule evaluation.


3. **Practical (Street Driving) Test:** On-road driving assessment.



* Includes automated Retake Test application processing for failed attempts.



### 3. 👥 Centralized People & Driver Registry

* **Person Management:** Single repository for citizen records tracked by unique National ID.


* **Driver Records:** Automatic promotion of applicants to official Driver status upon passing all required tests.



### 4. 🔐 System Administration & Security

* **User & Permission Management:** User account administration, active/inactive state toggles, and granular bitwise permission controls.


* **Dynamic Fee Management:** Configurable fees for application types, test fees, and license class rules.


* **Audit Logging:** Logs user IDs and timestamps across all transactional operations.



---

## 🛠️ Tech Stack & System Architecture

| Component | Technology | Description |
| --- | --- | --- |
| **Language** | C# (.NET Framework) | Strong-typed object-oriented logic. |
| **UI Layer** | Windows Forms (WinForms) | Custom `UserControl` components & responsive layout design. |
| **Database** | Microsoft SQL Server | Relational schema with indexed primary/foreign keys & stored procedures/queries. |
| **Data Access** | ADO.NET | Parameterized SQL execution to prevent SQL Injection vulnerabilities. |
| **Architecture** | 3-Tier Architecture | **UI** $\rightarrow$ **Business Logic Layer (BLL)** $\rightarrow$ **Data Access Layer (DAL)**. |

---

## 📄 License Classes Configuration

| Class ID | Class Name | Target Vehicle | Min Age | Validity |
| --- | --- | --- | --- | --- |
| **1** | Small Motorcycle | Small capacity motorbikes | 18

 | 5 Years

 |
| **2** | Heavy Motorcycle | Large capacity motorbikes | 21

 | 5 Years

 |
| **3** | Ordinary Driving | Personal light vehicles | 18

 | 10 Years

 |
| **4** | Commercial | Taxi / Limousine | 21

 | 10 Years

 |
| **5** | Agricultural | Tractors & farming machinery | 21

 | 10 Years

 |
| **6** | Small/Medium Bus | Minibuses | 21

 | 10 Years

 |
| **7** | Heavy Truck | Heavy vehicles & trailers | 21

 | 10 Years

 |

---

## 🚀 Getting Started

### Prerequisites

* Visual Studio 2022 (.NET Desktop Development Workload)
* Microsoft SQL Server (2019 or later) & SQL Server Management Studio (SSMS)

### Database Setup

1. Open SSMS and execute the provided `DVLD_Database_Schema.sql` script located in the `Database/` folder.
2. Update the `App.config` file in the UI project with your local SQL Server Connection String:

```xml
<connectionStrings>
  <add name="DVLD_Connection" 
       connectionString="Server=YOUR_SERVER_NAME;Database=DVLD;Trusted_Connection=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>

```
