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

![Screenshot_1](https://user-images.githubusercontent.com/11037848/149179710-2c7c1880-2364-4ab4-b402-ff9ecc80d9f0.png)

**Kafka Broker**

Is a running kafka instance, its a pyshical process that runs on the base operating system and listen on specific port, receive messages from producers and stores it on logs files (disk space). Consumer subscribe to specific topics, in the kafka broker, the broker will keep track of all active consumers. Kafka broker manane life cycle of topics, manage partitions. Multiple kafka borkers  can be clustered together to form a only kafka cluter. On the kafka cluter we can have a leader node will be in charge on manage other kafka brokers and manage fault tolerance. A topic can be replicated to different brokers among the cluster

![image](https://user-images.githubusercontent.com/11037848/149180673-d5c179e9-dba4-418e-949b-8e003759ed1a.png)

**Producers and Consumers**

A producer is a client that publishes data to kafka, a consumer is a client that process message published on a kafka topic

![image](https://user-images.githubusercontent.com/11037848/149182638-ea501aa5-b9a0-4180-b2fd-a74422403518.png)


