package com.foodclicker.game_service.game.shop.services.cosmetics.document;

import jakarta.persistence.Column;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;
import org.springframework.data.mongodb.core.mapping.Field;

@Getter
@Setter
@AllArgsConstructor
public class CosmeticsGroupElement {
    @Field(name = "item_id")
    private int itemId;
    private int price;
    @Field(name = "min_prestige")
    private int minPrestige;
}
