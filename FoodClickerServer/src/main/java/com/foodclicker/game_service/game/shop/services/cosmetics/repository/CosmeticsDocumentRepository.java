package com.foodclicker.game_service.game.shop.services.cosmetics.repository;

import com.foodclicker.game_service.game.shop.services.cosmetics.document.CosmeticsDocument;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface CosmeticsDocumentRepository extends MongoRepository<CosmeticsDocument, String> {
    
}
