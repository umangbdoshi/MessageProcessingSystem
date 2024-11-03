## Code Solution README

### Overview
JP Morgan Ireland interview coding task
This code solution focuses on solving the problem rather than its structure. While it may not be production-ready, the core logic is sound and effectively processes messages from the TestData.txt file. The application logs output after every 10th message and pauses after processing the 50th message.

### Features

1. Logic Emphasis: The code solution prioritizes the implementation of the underlying logic for message processing.

2. Logging and Pausing: The application successfully logs output after every 10th message, allowing progress tracking. After 50 messages the application logs that it is pausing, stop accepting new messages and log a report of the adjustments that have been made to each sale type while the application was running.

3. Refactor Possibility: The code solution is designed in such a way that it can be refactored into layers, making it more maintainable. The 10th and 50th message count can be made configurable.

4. .NET Framework Usage: The code is implemented using the **.NET Framework** due to limitations with .NET Core on my current machine. However, it can be easily adapted to .NET Core, and Dependency Injection (DI) can be introduced to enhance maintainability and unit testability. For example, services like SalesLog and SalesProcessor can be made **Singleton**.

### Conclusion

While the current code solution demonstrates a strong logic foundation, there are opportunities for improvement in terms of code structure, modularity, and maintainability. By considering the suggested improvements, the code can be enhanced to achieve production readiness and adhere to best coding practices.
