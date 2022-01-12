# Kafka Essentials

**Messages**

Unit of data that is collected, store and distribuited by Kafka. Kafka treats a message as a Byte array.

Message Content:
  - Key
    - Need not be unique
    - Defined by the producer
    - Used for partition
  - Value
    - Content of the message
    - User Defined
  - Timestamp
    - Automatically timestamped

**Topics**

Is an entity that holds mesages, works as a queue for similar messages. We can have multiple topics per kafka instance, support multiple Producers and Consumers, and Multiple partitios per topic

