# L4-Stress-Testing
 
All tests were run under Win 10. 
Used Siege 3.0.5, build for Windows.
Siege by some reason gave very low Concurrency values, that were far away from input params.
And all results from Siege looks pretty the same.

## Siege & App with DB reads:
![Results](https://github.com/GrigoriyYepick/L4-Stress-Testing/blob/main/siege_db.txt)


## Siege & App with cache:
![Results](https://github.com/GrigoriyYepick/L4-Stress-Testing/blob/main/siege_cache.txt)

JMeter (100 threads) shows that cahce works faster.

## JMeter & App with DB reads:
![alt text](https://github.com/GrigoriyYepick/L4-Stress-Testing/blob/main/jmeter_db.png)


## JMeter & App with cache:
![alt text](https://github.com/GrigoriyYepick/L4-Stress-Testing/blob/main/jmeter_cache.png)
