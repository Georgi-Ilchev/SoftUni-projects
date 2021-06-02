﻿namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Http;
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HttpMethod method, HttpResponse response);

        IRoutingTable MapGet(string url, HttpResponse response);
    }
}