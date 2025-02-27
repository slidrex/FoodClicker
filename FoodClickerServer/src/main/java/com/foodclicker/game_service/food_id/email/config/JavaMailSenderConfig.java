package com.foodclicker.game_service.food_id.email.config;

import com.sun.mail.smtp.SMTPAddressFailedException;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.ResponseEntity;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.JavaMailSenderImpl;
import org.springframework.web.bind.annotation.ExceptionHandler;

import java.util.Properties;
@Configuration
public class JavaMailSenderConfig {
    @Value("${application.mail-dispatcher.inbox}")
    private String inbox;
    @Value("${application.mail-dispatcher.password}")
    private String password;
    @Value("${application.mail-dispatcher.port}")
    private Integer port;
    @Value("${application.mail-dispatcher.host}")
    private String host;
    @Bean
    public JavaMailSender getJavaMailSender() {
        JavaMailSenderImpl mailSender = new JavaMailSenderImpl();
        mailSender.setHost(host);
        mailSender.setPort(port);

        mailSender.setUsername(inbox);
        mailSender.setPassword(password);
        
        Properties props = mailSender.getJavaMailProperties();
        props.put("mail.transport.protocol", "smtp");
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.debug", "true");

        return mailSender;
    }
    
}
