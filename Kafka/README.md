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

**Zookeeper**

Every kafka broker or cluster needs a Zookeeper instance, is used as a central, realtime information store for kafka, that helps on distributed syncronization. Zookeper helps on broker management, when we start a borker we have to resgitry on a zookeeper instance. One of the brokers registered on the zookeeper instance, tipically the first one is known as the active controller (lead node), it manage the others brokers registered on the broker, if for some reason the active controller fails, zookeper will handle the broker failure and assign another broker on the cluster as the active controller. Zookeper also helps with topics management

**Partitions**

A topic can have 1-n partitions. The number of partitions are set up during topic creation. The maximum number of partitions per cluster and per topic varies by the specific version of Kafka. Partitions allow Kafka to scale by parallelizing ingestion, storage, and consumption of messages. It provides horizontal scalability. Each partition has separate physical log files which of course will rollover as they reach configured sizes. A given message in Kafka is taught in only 1 partition. Each partition is assigned a broker process, known as its Leader broker. In order to write to a specific partition, the message needs to be sent to its corresponding leader. The leader takes care of updating its log file as well as replicating that partition to other copies. The leader will also send data to the subscribers of the partition, but multiple partitions for a topic. Consumers can share workloads by partitions using consumer groups. Partitions can also be replicated for fault tolerance purposes. There are a few things to note about partitions. These significantly impact the performance and latency of pipelines. Each published message gets stored in only 1 partition. If the partition is replicated, each replicated copy will also get an instant of this message. Message ordering is guaranteed only within a partition. So in the example provided, messages are pushed to Kafka in the order from M1 to M8. M1, M3, and M7 are guaranteed to be delivered to the consumer in the same sequence as they belong to a single partition. But on the other hand, there is no guarantee of ordering between M1 and M2 as they belong to different partitions. It is possible for M2 to be delivered before M1. The partition for a message is determined by its message key. Kafka uses a hashing function to allocate a partition based on the message key. Messages with the same key will always end up in the same partition. It is important to choose keys that have an equal distribution of its values. Otherwise some partitions may get overloaded while others will be used minimally. The number of partitions cannot be modified after the topic is created. Hence, care should be taken to set the right size for partitions during creation time. Now let's look at creating topics with multiple partitions and then publishing messages to these partitions.
![image](https://user-images.githubusercontent.com/11037848/149185836-a5842fdc-9a4c-44ad-99a5-f3fd660b774d.png)

