package com.foodclicker.game_service.game.shop.services.cosmetics.util;

import com.foodclicker.game_service.game.shop.services.cosmetics.document.CosmeticsDocument;
import com.foodclicker.game_service.game.shop.services.cosmetics.document.CosmeticsGroupElement;
import com.foodclicker.game_service.game.shop.services.cosmetics.exception.UnknownCosmeticsTemplateException;
import com.foodclicker.game_service.game.shop.services.cosmetics.model.PlayerCosmeticsModel;
import com.foodclicker.game_service.game.shop.services.cosmetics.repository.CosmeticsDocumentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class CosmeticsDocumentUtil {
    public static final int GROUP_COUNT = 2;
    @Autowired
    private CosmeticsDocumentRepository documentRepository;
    public CosmeticsGroupElement getCosmeticsElement(int groupId, int itemId) throws UnknownCosmeticsTemplateException {
        
        return CosmeticsDocument.getGroupById(getCosmeticsDocument(), groupId)
                .stream()
                .filter(x -> x.getItemId() == itemId)
                .findFirst()
                .orElseThrow(UnknownCosmeticsTemplateException::new);
    }
    public List<List<CosmeticsGroupElement>> getAllItems() throws UnknownCosmeticsTemplateException {
        
        var doc = getCosmeticsDocument();
        var groups = new ArrayList<List<CosmeticsGroupElement>>(GROUP_COUNT);
        for(int i = 0; i < GROUP_COUNT; i++) {
            var currentDoc = CosmeticsDocument.getGroupById(doc, i);
            groups.add(i, currentDoc);
        }
        return groups;
    }
    public CosmeticsDocument getCosmeticsDocument() {
        return documentRepository.findAll().get(0);
    }
}
