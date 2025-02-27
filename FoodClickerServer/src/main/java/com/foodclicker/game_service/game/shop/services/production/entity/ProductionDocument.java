package com.foodclicker.game_service.game.shop.services.production.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Id;
import lombok.Getter;
import lombok.Setter;
import org.springframework.data.mongodb.core.mapping.Document;

@Document("production")
@Getter
@Setter
public class ProductionDocument {
    @Id
    private String id;
    private String name;
    private Integer uid;
    private Integer basePrice;
    private Integer gpcPerLevel;
    private Integer gpsPerLevel;
}
