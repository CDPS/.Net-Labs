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

A topic can have 1-n partitions. The number of partitions are set up only on the topic creation. Partitions allow Kafka to scale by parallelizing ingestion, storage, and consumption of messages. Each partition has separate physical log files. Each partition is assigned a broker process, known as its Leader broker. In order to write to a specific partition, the message needs to be sent to its corresponding leader. The leader takes care of updating its log file as well as replicating that partition to other copies. The leader will also send data to the subscribers of the partition. Consumers can share workloads by partitions using consumer groups. Partitions can also be replicated for fault tolerance purposes. These significantly impact the performance and latency of pipelines. Each published message gets stored in only 1 partition. If the partition is replicated, each replicated copy will also get an instant of this message. Message ordering is guaranteed only within a partition. So in the example provided, messages are pushed to Kafka in the order from M1 to M8. M1, M3, and M7 are guaranteed to be delivered to the consumer in the same sequence as they belong to a single partition. But on the other hand, there is no guarantee of ordering between M1 and M2 as they belong to different partitions. It is possible for M2 to be delivered before M1. The partition for a message is determined by its message key. Kafka uses a hashing function to allocate a partition based on the message key. Messages with the same key will always end up in the same partition. It is important to choose keys that have an equal distribution of its values. Otherwise some partitions may get overloaded while others will be used minimally. The number of partitions cannot be modified after the topic is created. Hence, care should be taken to set the right size for partitions during creation time. Now let's look at creating topics with multiple partitions and then publishing messages to these partitions.

<p align="center">
   <img src="https://user-images.githubusercontent.com/11037848/149185836-a5842fdc-9a4c-44ad-99a5-f3fd660b774d.png" alt="Sublime's custom image"/>
</p>

**Consumer Groups**

 A consumer group is a group of consumers that share a topic workload. For scalability, multiple consumer processes can be started and the messages can be distributed among them. For load balancing, a consumer group is a logical group of consumers that Kafka users for such low distribution. Each message will be sent to only one consumer within a consumer group, that consumer is then responsible for processing the message and acknowledging back to Kafka. Kafka, keep tracks of the active number of consumers for a given topic, it then distributes the messages evenly between these consumers. Kafka only considers the number of partitions for distribution, not the number of messages expected in each partition. It is expected that the number of partitions are equal to are higher than the number of consumers in a group. If there are more consumers than partitions, then there will be consumers with no work as the lowest granularity of work distribution is a partition. We can create multiple consumer groups each with a different set of consumers. Each group will get a full copy of all the messages, but each message will be sent only to one consumer within each consumer group. When new consumers come up or existing consumers go down, Kafka takes care of rebalancing the load by reassigning partitions among live consumers. Kafka users heartbeats with consumers to keep track of their health. Let's look at an example for consumer groups here. We have a topic called orders, it has three partitions P1 want to P3. There are eight messages numbered M1 to M8. There are two consumer group creator. The first consumer group is an analytics consumer group that has three consumers. The second is an audit consumer group that has two consumers. For the analytics consumer group as a number of partitions and consumers or equal, Kafka assigns one partition per consumer. For the audit consumer group as the number of consumers are less than the number of partitions, Kafka assigns one partition to the first consumer and two partitions to the second consumer, but both consumer groups get a copy of all the messages. In the next video, let us explore how Kafka keep tracks of what messages are consumed and if it needs to recent data towards consumers.
 
![image](https://user-images.githubusercontent.com/11037848/149188141-ea7fa570-85b6-45b3-9f80-501ef0506dd4.png)

**Consumer Offset**

It is a number to track message consumption by each consumer and partition. As each message is received by Kafka, it allocates a message ID to the message. Kafka then maintains the message ID offset on a by consumer and by partition basis to track consumption. Kafka brokers keep track of both what is sent to the consumer and what is acknowledged by the consumer by using two offset values. The Current offset value tracks the last message ID that was sent to the consumer. The committed offset value tracks the last message that is acknowledged by the consumer. As consumers receive a message, they have the option of acknowledging immediately or after making sure that all required processing is done. This helps consumers to manage transactions and not lose messages in case of failures. By default, Kafka consumers auto acknowledge on receipt, but this can be changed by the consumer. When Kafka brokers do not receive acknowledgement within a set timeout they will resend the message to the consumer. This ensures at least once delivery of each message to a consumer group. A message can be delivered multiple times if acknowledgement does not happen within a timeout but each message will be delivered at least once. When a consumer group starts up, it has the option of requesting messages either from the start, only the latest, or from given offset. This allows the consumers to process messages based on their use case requirements.

![image](https://user-images.githubusercontent.com/11037848/149188988-5878552a-8c1b-4865-b2d6-7ed39f43b9ec.png)

![image](https://user-images.githubusercontent.com/11037848/149189083-05ffe41b-3a3d-42b1-91a0-d7b1c5d97b3f.png)

