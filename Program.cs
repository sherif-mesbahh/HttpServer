﻿using HttpListener = HTTPServer.HTTPListener.HttpListener;

var server = new HttpListener(8080);
await server.Start();