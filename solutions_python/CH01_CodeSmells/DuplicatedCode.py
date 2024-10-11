from datetime import datetime
import logging
from typing import Literal

"""
```csharp
public void LogError(string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    string formattedMessage = $"ERROR: [{formattedTimestamp}] {message}";
    Console.WriteLine(formattedMessage);
}

public void LogWarning(string message, DateTime timestamp)
{
    string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    string formattedMessage = $"WARNING: [{formattedTimestamp}] {message}";
    Console.WriteLine(formattedMessage);
}
"""
logger = logging.Logger(name=__name__)


class DuplicatedCode: 
    @staticmethod
    def format_log_message(message: str, 
                           datetime: datetime,
                           level: Literal["warning", "error"],
                           logger: logging.Logger=logger) -> None:
        formatted_timestamp = datetime.strftime("%Y-%m-%d %H:%M:%S")
        if level == "warning":
            return logger.warning(f"WARNING: [{formatted_timestamp}] {message}")
        logger.error(f"ERROR: [{formatted_timestamp}] {message}")


if __name__ == "__main__":
    logger_msg_warninig = DuplicatedCode.format_log_message(
        message="test_message",
        level="warning",
        datetime=datetime.now()
    )
    
    logger_msg_error = DuplicatedCode.format_log_message(
        message="test_message",
        level="error",
        datetime=datetime.now()
    )



