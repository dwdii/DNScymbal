DNSimple Record Updater Windows .Net Tray app / Service
=======================================================
A simple Windows tray app with a property sheet for configuration:

    EmailAddress: your DNSimple email address
    Password: your DNSimple password
    Domain: yourdomain.com
    Record ID: Record Id of the DNS record to update
    Record Name: Name of the DNS Record to be updated
    Update Frequency: Interval in minutes between updates.

Use the DNSimple web interface to create the initial A record and then allow the DNScymbal to maintain it according to your public IP.

The DNScymbal app will automatically use the jsonip.com service to get your public IP address
and post this IP to the specified record on the specified domain.

DNScymbal uses the [DNSimple-csharp](https://github.com/anderly/dnsimple-csharp) API via NuGet as well as [JsonFx](https://github.com/jsonfx/jsonfx).