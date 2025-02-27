package com.foodclicker.game_service.game.shop.services.cosmetics.document;

import com.foodclicker.game_service.game.shop.services.cosmetics.exception.UnknownCosmeticsTemplateException;
import jakarta.persistence.Column;
import jakarta.persistence.Id;
import lombok.Getter;
import lombok.Setter;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.Field;

import java.util.ArrayList;
import java.util.List;

@Document("cosmetics")
@Getter
@Setter
public class CosmeticsDocument {
    @Id
    private String id;
    private List<CosmeticsGroupElement> background;
    @Field("food_image")
    private List<CosmeticsGroupElement> foodImage;
    public static List<CosmeticsGroupElement> getGroupById(CosmeticsDocument document, int groupId) throws UnknownCosmeticsTemplateException {
        
        switch (groupId) {
            case 0:
                return document.background;
            case 1:
                return document.foodImage;
        }
        
        throw new UnknownCosmeticsTemplateException();
    }
}
