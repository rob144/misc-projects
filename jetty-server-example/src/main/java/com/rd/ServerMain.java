package com.rd;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.eclipse.jetty.server.Request;
import org.eclipse.jetty.server.Server;
import org.eclipse.jetty.server.Handler;
import org.eclipse.jetty.server.handler.DefaultHandler;
import org.eclipse.jetty.server.handler.HandlerList;
import org.eclipse.jetty.server.handler.ResourceHandler;
 
public class ServerMain {
 
    public static void main(String[] args) throws Exception {
        Server server = new Server(8080);

        ResourceHandler resHandler = new ResourceHandler();
        // Configure the ResourceHandler. Setting the resource base indicates where the files should be served out of.
        // In this example it is the current directory but it can be configured to anything that the jvm has access to.
        resHandler.setDirectoriesListed(true);
        resHandler.setWelcomeFiles(new String[]{ "index.html" });
        resHandler.setResourceBase("target/webapp");
 
        // Add the ResourceHandler to the server.
        HandlerList handlers = new HandlerList();
        handlers.setHandlers(new Handler[] { resHandler });
        server.setHandler(handlers);

        //server.setHandler(new HelloWorld());
        server.start();
        server.join();
    }
}
