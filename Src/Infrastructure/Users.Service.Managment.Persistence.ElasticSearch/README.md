# Persistence.ElasticSearch Layer

This layer is part of the persistence layer
It is for elastic seach reading and writing purposes
It implements interfaces defined in the application layer
This layer is fully pluggable because the implementation of getting or setting the data from or to the data-store exists in this layer not in the application layer
So we may use another data-store such as Excel files
