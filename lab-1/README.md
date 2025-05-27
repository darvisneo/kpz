
## Programming Principles Demonstrated in the Project

This lab project demonstrates several key software engineering principles. Each principle is explained below along with code references that illustrate how they are followed.

---

### 1. **Single Responsibility Principle (SRP)** — \[S in SOLID]

**Definition:** A class should have only one reason to change.

* ✅ `Money` handles money representation and operations.
  📄 [`Money.cs`](./lab-1/Money.cs#L9-L42), lines 9–42
* ✅ `Product` encapsulates product data and operations related to pricing.
  📄 [`Product.cs`](./lab-1/Product.cs#L19-L32), lines 10–32
* ✅ `Warehouse` is responsible only for inventory storage and shipment.
  📄 [`Warehouse.cs`](./lab-1/Warehouse.cs#L10-L41), lines 10–41
* ✅ `Reporting` only handles reporting logic.
  📄 [`Reporting.cs`](./lab-1/Reporting.cs#L10-L17), lines 10–17

---

### 2. **Open/Closed Principle (OCP)** — \[O in SOLID]

**Definition:** Classes should be open for extension but closed for modification.

* ✅ You can extend functionality by adding new product types or pricing logic without changing existing classes like `Product` or `Money`.
  📄 [`Product.cs`](./lab-1/Product.cs#L10-L32), lines 10–32

---

### 3. **Liskov Substitution Principle (LSP)** — \[L in SOLID]

**Definition:** Derived classes must be substitutable for their base classes.

* ⚠️ Not applicable here explicitly (no inheritance used), but the design would allow it—for example, if `Product` had derived types.

---

### 4. **Interface Segregation Principle (ISP)** — \[I in SOLID]

**Definition:** Clients should not be forced to depend on methods they do not use.

* ⚠️ No interfaces are defined in this lab, so this principle is not directly demonstrated.

---

### 5. **Dependency Inversion Principle (DIP)** — \[D in SOLID]

**Definition:** High-level modules should not depend on low-level modules. Both should depend on abstractions.

* ⚠️ Not fully demonstrated — but the `Reporting` class depends on the abstract behavior of `Warehouse`, which could be abstracted with an interface in future.

---

### 6. **DRY (Don't Repeat Yourself)**

**Definition:** Avoid duplicating code.

* ✅ Reused logic for manipulating money (`SetAmount`, `Decrease`) is centralized in `Money` class.
  📄 [`Money.cs`](./lab-1/Money.cs#L9-L42), lines 9–42
* ✅ `Warehouse.ShowInventory` and `Reporting.ShowInventoryReport` reuse the same inventory display logic.
  📄 [`Warehouse.cs`](./lab-1/Warehouse.cs#L19), line 19
  📄 [`Reporting.cs`](./lab-1/Reporting.cs#L14), line 14

---

### 7. **KISS (Keep It Simple, Stupid)**

**Definition:** Design should avoid unnecessary complexity.

* ✅ All classes and methods are short, intuitive, and clearly named.
  📄 All classes
  📄 [`Program.cs`](./lab-1/Program.cs#L9-L46), lines 9–46

---

### 8. **YAGNI (You Aren’t Gonna Need It)**

**Definition:** Don’t implement functionality until it is necessary.

* ✅ No unused features or complex abstractions — e.g., no unnecessary inheritance or interfaces.
  📄 Overall design: minimal and practical, focusing on required operations.

---

### 9. **Composition Over Inheritance**

**Definition:** Prefer composition over class inheritance.

* ✅ `WarehouseItem` contains a `Product` object rather than extending it.
  📄 [`WarehouseItem.cs`](./lab-1/WarehouseItem.cs#L10), line 10

---

### 10. **Program to Interfaces, Not Implementations**

**Definition:** Use interfaces to reduce coupling.

* ⚠️ Not used explicitly, but potential exists (e.g., `IWarehouse`, `IReportable`).

---

### 11. **Fail Fast**

**Definition:** The system should report errors early.

* ✅ In `Warehouse.ShipProduct`, the method immediately prints an error if shipment is not possible.
  📄 [`Warehouse.cs`](./lab-1/Warehouse.cs#L28-L40), lines 28–40
* ✅ In `Money.SetAmount`, logic corrects invalid `kopika` input (e.g., >100) early.
  📄 [`Money.cs`](./lab-1/Money.cs#L13-L17), lines 13–17

---

✅ **Total Principles Demonstrated**: 8

---