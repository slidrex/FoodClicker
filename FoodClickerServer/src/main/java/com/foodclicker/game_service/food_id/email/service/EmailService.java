package com.foodclicker.game_service.food_id.email.service;

import com.foodclicker.game_service.food_id.email.dto.EmailCodeRequest;
import com.foodclicker.game_service.food_id.email.dto.MailSendResponse;
import com.sun.mail.smtp.SMTPAddressFailedException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.mail.MailException;
import org.springframework.mail.MailParseException;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.security.access.annotation.Secured;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.ExceptionHandler;

import javax.xml.datatype.Duration;
import java.util.Random;
import java.util.concurrent.TimeUnit;

@Service
public class EmailService {
    @Value("${application.mail-dispatcher.subject}")
    private String subject;
    @Value("${application.mail-dispatcher.inbox}")
    private String inbox;
    @Autowired
    private JavaMailSender emailSender;
    @Autowired
    private RedisTemplate redisTemplate;
    public MailSendResponse sendConfirmationCode(EmailCodeRequest request) {
        Random random = new Random();
        
        //request.setEmail(request.getEmail().substring(0, request.getEmail().length() - 1));
        
        int randomCode = random.ints(1000, 9999).findFirst().getAsInt();
        redisTemplate.opsForValue().set(request.getEmail(), Integer.toString(randomCode), 5, TimeUnit.MINUTES);
        sendSimpleMessage(request.getEmail(), getConfirmationCodeMessage(randomCode));
        return MailSendResponse.builder().status("Confirmation code sent to email " + request.getEmail()).build();
    }
    private String getConfirmationCodeMessage(int code) {
        return "Your confirmation code is: " +Integer.toString(code) + 
               "\nDon't tell it to anyone!";
    }
    private void sendSimpleMessage(
            String to, String text) {
        
        SimpleMailMessage message = new SimpleMailMessage();
        message.setFrom(inbox);
        message.setTo(to);
        message.setSubject(subject);
        message.setText(text);
        
        emailSender.send(message);
    }
    
}
