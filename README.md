# 🕳️ Black Hole Garbage Collector (Noir)

Meet Noir! An artificial made Black-Hole purpose to swept any irregularities caused a cosmic disturbance from harming singularities.



This is are application cosmic-themed visualizer for the Generational Garbage Collection algorithm, built with C# and Avalonia UI to simulates how a modern runtime environment (like .NET or JVM) manages memory allocation, identifies unused references, and reclaims memory using a "Mark-and-Sweep" and Generational approach—all visualized through the gravitational pull of a Black Hole.

---

## Features
* **Interactive Memory Allocation:** Spawn space entities (Planets and Asteroids) to simulate memory allocation in RAM.
* **Mark-and-Sweep Visualization:** Visually distinguish active memory references from isolated (garbage) objects.
* **Generational GC Mechanics:** Watch objects survive the sweeping phase and get promoted through memory generations (Gen 0 → Gen 1 → Gen 2).
* **Real-time Memory Distortion Graph:** An EKG-style graph that dynamically reacts to memory load and garbage collection events.

---

## How the Software Works

This application demonstrates the core concepts of memory management through cosmic analogies:

### 1. Allocation (Spawning)
When you click **Spawn Planet** or **Spawn Asteroid**, the software instantiates a new object in the heap memory. 
* **Reality:** RAM usage increases. The EKG graph starts to spike, representing memory allocation.
* **Generational GC:** All newly created objects are born in **Gen 0** (Generation 0).

### 2. The "Mark" Phase
When you click **Mark as Garbage**, the software simulates a loss of reference.
* **Reality:** The application's root no longer points to this object. The Garbage Collector marks it as "unreachable" or garbage.
* **Visual:** The object turns transparent/red, signaling it has lost its gravitational orbit and is ready to be collected.

### 3. The "Sweep" Phase (Activate Black Hole)
Triggering the Black Hole activates the Garbage Collector to clean the heap.
* **Reality:** The GC sweeps through the memory, destroying all marked (unreachable) objects and freeing up RAM. The memory usage graph stabilizes.
* **Visual:** Marked objects are sucked into the Black Hole's void and permanently removed from the UI.



### 4. Generational Promotion (Survival)
Modern Garbage Collectors use the *Generational Hypothesis*, which states that most objects die young. 
* If an object is **not** marked as garbage when the Black Hole sweeps, it means the object is still in use. 
* To optimize future sweeps, the GC promotes these surviving objects to older generations. In this app, survivors are promoted from **Gen 0 → Gen 1**, and subsequently from **Gen 1 → Gen 2**. Objects in Gen 2 are considered long-lived data (like persistent database connections or the main UI window).

---

## Prerequisites

To run or compile this project locally, you will need:
* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (or the version specified in your `.csproj`).
* Git (to clone the repository).

---

## Getting Started

### Running the Project Locally
Open your terminal, navigate to the project directory, and execute the following command:
```bash
dotnet run

for building or publish use:
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true