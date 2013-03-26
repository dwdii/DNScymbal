DNScymbal
=========
DNScymbal is a simple Windows tray app which updates a DNSimple DNS record with your dynamic IP address. 

How to Get DNScymbal
====================
[Download the latest version of DNScymbal (1.0.4464)](http://www.dittenhafer.net/downloads/DNScymbal/DNScymbalSetup.msi)

Alternatively, fork the DNScymbal repo, build the solution yourself and start adding new functionality! 

I anticipate publishing a [Chocolatey.org](http://chocolatey.org/) package at some point, but unfortunately don't have a timeline for this yet.

How to Use DNScymbal
====================
DNScymbal uses a property sheet for configuration as shown below:

![DNScymbal Properties](https://raw.github.com/dwdii/DNScymbal/master/readme/DnsCymbalProperties.png "DNScymbal Properties")

    EmailAddress: your DNSimple email address

    Password: your DNSimple password

    Domain: yourdomain.com

    Record ID: Record Id of the DNS record to update

    Record Name: Name of the DNS Record to be updated

    Update Frequency: Interval in minutes between updates.

Use the DNSimple web interface to create the initial "A" record and then allow the DNScymbal application to maintain it according to your public IP.

The DNScymbal app will automatically use the [jsonip.com](http://jsonip.com/) service to get your public IP address
and post this IP to the specified record on the specified domain.

Development Environment
=======================
DNScymbal is a Visual Studio 2010 solution which uses the [DNSimple-csharp](https://github.com/anderly/dnsimple-csharp) API via NuGet 
as well as [JsonFx](https://github.com/jsonfx/jsonfx).

Requirements
============
The .Net Framework v4 Client Profile is required.

Testing
=======
Only lite manual testing on Windows 7 Home Premium has been performed. 

Please submit enhancements and issues via [this repo's issue tracking page](https://github.com/dwdii/DNScymbal/issues)

License
=======
MIT License

