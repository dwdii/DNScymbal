DNScymbal
=========
DNScymbal is a simple Windows tray app which updates a DNSimple DNS record with your dynamic IP address. 

How to Get DNScymbal
====================
[Download the latest version of DNScymbal (1.1.5410)](http://www.dittenhafer.net/downloads/DNScymbal/DNScymbalSetup-1.1.5410.msi)

[Download the previous version of DNScymbal (1.0.4464))](http://www.dittenhafer.net/downloads/DNScymbal/DNScymbalSetup.msi)

Alternatively, fork the DNScymbal repo, build the solution yourself and start adding new functionality! 

How to Use DNScymbal
====================
DNScymbal uses a property sheet for configuration as shown below:

![DNScymbal Properties](https://raw.github.com/dwdii/DNScymbal/master/readme/DnsCymbalProperties.png "DNScymbal Properties")

    EmailAddress: your DNSimple email address

    Password / API Token: your DNSimple password or API Token

	Is API Token: If using your API token (recommended), make sure this checkbox is checked

    Domain: yourdomain.com

    Record ID: Record Id of the DNS record to update. The Record Id can be found in the Advanced Editor for your domain.

    Record Name: Name of the DNS Record to be updated

    Update Frequency: Interval in minutes between updates.

Use the [DNSimple web interface](https://dnsimple.com/domains) to create the initial "A" record and then allow the DNScymbal application to maintain it according to your public IP.

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
Only lite manual testing on Windows 7 Professional has been performed. 

Please submit enhancements and issues via [this repo's issue tracking page](https://github.com/dwdii/DNScymbal/issues)

License
=======
MIT License

