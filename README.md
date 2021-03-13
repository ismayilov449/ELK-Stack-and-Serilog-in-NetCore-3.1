# ELK-Stack-and-Serilog-in-NetCore-3.1
 
**“ELK”** is the acronym for three open-source projects: Elasticsearch, Logstash and Kibana.

• **Serilog** - Serilog is a logging framework for .NET that launched in 2013. Serilog is one of the newest logging frameworks, so it takes some of the newer and more advanced features of .NET. Structured logging.  You can download it from : https://www.nuget.org/packages/Serilog/2.10.1-dev-01285

• **Elasticsearch** - Elasticsearch is an open-source, distributed, RESTful search and analytics engine. Don’t think that Elasticsearch only fits with large data as it allows you to start small, but will grow together with your business. Elasticsearch is built to scale horizontally.
 Elasticsearch is a highly available and distributed search engine. Each index is broken down into shards, and each shard can have one or more replica. By default, an index is created with 5 shards and 1 replica per shard (5/1). There are many topologies that can be used:
 
 • 1/10: 1 shard and 10 replicas — it helps to improve search performance.
 
 • 20/1: 20 shards and 1 replica per shard — it helps to improve indexing performance.
Elasticsearch is API driven. Most actions can be performed using a simple RESTful API using JSON over HTTP. 
You can download it from : https://www.elastic.co/downloads/elasticsearch

• **Logstash** - Logstash is responsible for aggregating data from different sources, processing it, and sending it down the pipeline, usually to be directly indexed in Elasticsearch.
Logstash can pull from almost any data source using input plugins, apply a wide variety of data transformations and enhancements using filter plugins, and ship the data to a large number of destinations using output plugins.
You can download it from : https://www.elastic.co/downloads/logstash

• **Kibana** - Kibana is a powerful visualisation tool that is integrated with Elasticsearch and uses your data which is stored in Elasticsearch clusters to create meaningful graphs and charts. Kibana’s core feature is data querying and analysis.
You can download it from : https://www.elastic.co/downloads/kibana

**Note** - After download Elasticsearch and Kibana,you have to configure **"~\elasticsearch-x.x.x\elasticsearch-x.x.x\config\elasticsearch.yml"** and **"~\kibana-x.x.x\kibana-x.x.x\config\kibana.yml"**.
**Note** - Username,password and encryption keys are optional.You can configure kibana&elasticsearch without them

Change credentials and add this configs to your elasticsearch.yml file
![image](https://user-images.githubusercontent.com/45458681/111024246-0c36a280-83f7-11eb-8d80-3a91767d9951.png)

Change credentials and add this configs to your elasticsearch.yml file
![image](https://user-images.githubusercontent.com/45458681/111024341-b8788900-83f7-11eb-99df-15813c52b846.png)


After configuring Elastichsearch and Kibana,you are free to use them.
Go **"~\elasticsearch-x.x.x\elasticsearch-x.x.x\bin"** directory and run powershell as administrator.Write to console "elasticsearch.bat"
![image](https://user-images.githubusercontent.com/45458681/111024512-9b908580-83f8-11eb-92a9-54862df6c6b0.png)
after this operation Elasticsearch starts
![image](https://user-images.githubusercontent.com/45458681/111024670-70f2fc80-83f9-11eb-92d3-0848b5b6919a.png)


Go **"~\elasticsearch-x.x.x\elasticsearch-x.x.x\bin"** directory and run powershell as administrator.Write to console "kibana.bat"
![image](https://user-images.githubusercontent.com/45458681/111024912-946a7700-83fa-11eb-8ed6-1a5ca73591b7.png)
after this operation Kibana starts
![image](https://user-images.githubusercontent.com/45458681/111024810-1dcd7980-83fa-11eb-8e2c-5223c4414f70.png)

Then go http://localhost:[kibana:port] and discover Kibana.
