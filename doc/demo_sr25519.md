# Manual Demos - Milestone 2

SR25519 deliverables are located in master branch of this repository.

### Build and run Docker image

```
$ docker build -t sr25519 .
$ docker run -it --rm sr25519 /bin/bash
```

Now you are connected to a running docker container with API built. You can execute following commands to examine deliverables.

### Build project and run tests

```
# dotnet build
# dotnet test
# dotnet test --filter <test name>
```

### Sign message and verify using Polkadot Web UI 

First, run sr25519 test to get a signature for a message. Both Kusama and Alexander use the same version of signature, so there is no need to test on both.

```
# cd ../sr25519_test
# dotnet test --filter sr25519
Merlin/Merlin.cs(255,21): warning CS0414: The field 'TranscriptRng._pointer' is assigned but its value is never used [/src/Schnorrkel/Schnorrkel.csproj]
Test run for /src/PolkaTest/bin/Debug/netcoreapp2.2/PolkaTest.dll(.NETCoreApp,Version=v2.2)
Microsoft (R) Test Execution Command Line Tool Version 16.2.0-preview-20190606-02
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
Message: 0xAD641BE7A2704CA665269BBFE34F9DAA23F54C69
Signature: 0xEAFD9BC207BBEA90784E22694D1646C2F05A202DEDB7AB7B2EB19BB92EF9E573361BDCFDBBD96549FEDBE6E3A4BEC6AED2733BF31D16F64CA9E843D8D2D5B20B

```

Next, copy the information below as well as the newly generated message and signature and paste in the UI to verify:

```
URL: https://polkadot.js.org/apps/#/toolbox/verify
Address: HRXczFqEHbehYTvdBxX1K62QaPhJywEy5BKxHdJnE8wfHH1
Message: 0xAD641BE7A2704CA665269BBFE34F9DAA23F54C69
Signature example: 0xEAFD9BC207BBEA90784E22694D1646C2F05A202DEDB7AB7B2EB19BB92EF9E573361BDCFDBBD96549FEDBE6E3A4BEC6AED2733BF31D16F64CA9E843D8D2D5B20B
```

