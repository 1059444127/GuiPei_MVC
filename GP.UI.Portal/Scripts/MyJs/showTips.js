function showDIVTip() {
    $("#ZhuSu").focus(function () {
        $("#DZhuSu").fadeIn("slow").css("color", "red").html("（主诉要简明精练，一般1-2句话，20字左右）");
    }).blur(function () {
        $("#DZhuSu").fadeOut("slow");
    });
    $("#XBShi_FBQK").focus(function () {
        $("#DXBShi_FBQK").fadeIn("slow").css("color", "red").html("（记录发病的时间、地点、起病缓急、前驱症状、可能的原因或诱因）");
    }).blur(function () {
        $("#DXBShi_FBQK").fadeOut("slow");
    }); 
    $("#XBShi_ZYZZ").focus(function () {
        $("#DXBShi_ZYZZ").fadeIn("slow").css("color", "red").html("（按发生的先后顺序描述主要的症状的部位、性质、持续的时间、程度、缓解或加剧因素以及演变的发展状况）");
    }).blur(function () {
        $("#DXBShi_ZYZZ").fadeOut("slow");
    });
    $("#XBShi_BSZZ").focus(function () {
        $("#DXBShi_BSZZ").fadeIn("slow").css("color", "red").html("（记录伴随症状，描述伴随症状与主要症状之间的相互关系）");
    }).blur(function () {
        $("#DXBShi_BSZZ").fadeOut("slow");
    });
    $("#XBShi_FBYL").focus(function () {
        $("#DXBShi_FBYL").fadeIn("slow").css("color", "red").html("（记录患者发病后到入院前，在院内、外接受检查与治疗的详细经过及效果。对患者提供的药名、诊断和手术名称需加引号以示区别）");
    }).blur(function () {
        $("#DXBShi_FBYL").fadeOut("slow");
    });
    $("#XBShi_FBYLY").focus(function () {
        $("#DXBShi_FBYLY").fadeIn("slow").css("color", "red").html("（简要记录患者发病后的精神状态、睡眠、饮食、大小便、体重等情况）");
    }).blur(function () {
        $("#DXBShi_FBYLY").fadeOut("slow");
    });
    $("#XBShi_QT").focus(function () {
        $("#DXBShi_QT").fadeIn("slow").css("color", "red").html("（记录与本次疾病虽无密切关系，但仍需治疗的其他疾病情况）");
    }).blur(function () {
        $("#DXBShi_QT").fadeOut("slow");
    });
    $("#JWShi_YBJK").focus(function () {
        $("#DJWShi_YBJK").fadeIn("slow").css("color", "red").html("（既往一般健康状况）");
    }).blur(function () {
        $("#DJWShi_YBJK").fadeOut("slow");
    });
    $("#JWShi_JBS").focus(function () {
        $("#DJWShi_JBS").fadeIn("slow").css("color", "red").html("（如：高血压、糖尿病、恶性肿瘤、结核病、冠心病、脑卒中等）");
    }).blur(function () {
        $("#DJWShi_JBS").fadeOut("slow");
    });
    $("#JWShi_CRBS").focus(function () {
        $("#DJWShi_CRBS").fadeIn("slow").css("color", "red").html("（传染性疾病）");
    }).blur(function () {
        $("#DJWShi_CRBS").fadeOut("slow");
    });
    $("#JWShi_YFJZ").focus(function () {
        $("#DJWShi_YFJZ").fadeIn("slow").css("color", "red").html("（接种疫苗）");
    }).blur(function () {
        $("#DJWShi_YFJZ").fadeOut("slow");
    }); 
    $("#JWShi_SSWS").focus(function () {
        $("#DJWShi_SSWS").fadeIn("slow").css("color", "red").html("（记录手术（外伤）时间、医院、手术（外伤）结果等）");
    }).blur(function () {
        $("#DJWShi_SSWS").fadeOut("slow");
    });
    $("#JWShi_SXS").focus(function () {
        $("#DJWShi_SXS").fadeIn("slow").css("color", "red").html("（记录输血时间、原因、输血量、输血结果等）");
    }).blur(function () {
        $("#DJWShi_SXS").fadeOut("slow");
    });
    $("#JWShi_SWYW").focus(function () {
        $("#DJWShi_SWYW").fadeIn("slow").css("color", "red").html("（如：青霉素过敏、链霉素过敏、普鲁卡因过敏、细胞色素C过敏、碘过敏、磺胺过敏、花粉过敏等）");
    }).blur(function () {
        $("#DJWShi_SWYW").fadeOut("slow");
    });

    $("#JWShi_QT").focus(function () {
        $("#DJWShi_QT").fadeIn("slow").css("color", "red").html("（其他情况）");
    }).blur(function () {
        $("#DJWShi_QT").fadeOut("slow");
    });
    $("#XTHGu_HXXT").focus(function () {
        $("#DXTHGu_HXXT").fadeIn("slow").css("color", "red").html("（慢性咳嗽、咳痰、呼吸困难、咳血、低热、盗汗、与肺结核患者密切接触史）");
    }).blur(function () {
        $("#DXTHGu_HXXT").fadeOut("slow");
    });
    $("#XTHGu_XHXT").focus(function () {
        $("#DXTHGu_XHXT").fadeIn("slow").css("color", "red").html("（心悸、气急、咳血、发绀，心前区痛、晕厥、水肿及高血压、动脉硬化、心脏疾病、风湿热病史等）");
    }).blur(function () {
        $("#DXTHGu_XHXT").fadeOut("slow");
    });
    $("#XTHGu_XHuaXT").focus(function () {
        $("#DXTHGu_XHuaXT").fadeIn("slow").css("color", "red").html("（慢性腹胀、腹痛、嗳气、反酸、呕血、便血、黄疸和慢性腹泻、便秘史等）");
    }).blur(function () {
        $("#DXTHGu_XHuaXT").fadeOut("slow");
    });
    $("#XTHGu_MNXT").focus(function () {
        $("#DXTHGu_MNXT").fadeIn("slow").css("color", "red").html("（尿频、尿急、尿痛、排尿不畅或淋沥，尿色（洗肉水样或酱油色），清浊度，水肿，肾毒性药物应用史，铅、汞化学毒物接触或中毒史以及下疳、淋病、梅毒等性病史）");
    }).blur(function () {
        $("#DXTHGu_MNXT").fadeOut("slow");
    });
    $("#XTHGu_ZXXT").focus(function () {
        $("#DXTHGu_ZXXT").fadeIn("slow").css("color", "red").html("（头晕、乏力，皮肤或黏膜瘀点、紫癜、血肿，反复鼻出血，牙龈出血，骨骼痛，化学药品、工业毒物、放射性物质接触史等）");
    }).blur(function () {
        $("#DXTHGu_ZXXT").fadeOut("slow");
    });
    $("#XTHGu_NFMXT").focus(function () {
        $("#DXTHGu_NFMXT").fadeIn("slow").css("color", "red").html("（畏寒、怕热、多汗、食欲异常、烦渴、多饮、多尿、头痛、视力障碍、肌肉震颤、性格、体重、皮肤、毛发和第二性征改变史等）");
    }).blur(function () {
        $("#DXTHGu_NFMXT").fadeOut("slow");
    });
    $("#XTHGu_SJJS").focus(function () {
        $("#DXTHGu_SJJS").fadeIn("slow").css("color", "red").html("（头痛、失眠或嗜睡、意识障碍、晕厥、痉挛、瘫痪、视力障碍、感觉及运动异常、性格改变、记忆力和智能减退等）");
    }).blur(function () {
        $("#DXTHGu_SJJS").fadeOut("slow");
    });
    $("#XTHGu_JRGG").focus(function () {
        $("#DXTHGu_JRGG").fadeIn("slow").css("color", "red").html("（关节肿痛、运动障碍、肢体麻木、痉挛、萎缩、瘫痪史等）");
    }).blur(function () {
        $("#DXTHGu_JRGG").fadeOut("slow");
    });

    $("#GRShi").focus(function () {
        $("#DGRShi").fadeIn("slow").css("color", "red").html("（记录出生地及长期居留地，生活习惯及有无烟酒等嗜好，常用药物，职业与工作条件及有无工业毒物、粉尘、放射性物质接触史，有无冶游史）");
    }).blur(function () {
        $("#DGRShi").fadeOut("slow");
    });
    $("#HYShi").focus(function () {
        $("#DHYShi").fadeIn("slow").css("color", "red").html("（记录婚姻状况、结婚年龄、配偶健康状况、子女状况、性生活情况等）");
    }).blur(function () {
        $("#DHYShi").fadeOut("slow");
    });
    $("#YJShi").focus(function () {
        $("#DYJShi").fadeIn("slow").css("color", "red").html("（记录格式为：初潮年龄 行经期天数/月经周期天数 末次月经时间（或绝经年龄），并记录月经量、颜色，有无血块、痛经、白带等情况）");
    }).blur(function () {
        $("#DYJShi").fadeOut("slow");
    });

    $("#SYShi").focus(function () {
        $("#DSYShi").fadeIn("slow").css("color", "red").html("（按照以下顺序：足月分娩数-早产数-流产或人流数-存活数。并记录计划生育措施）");
    }).blur(function () {
        $("#DSYShi").fadeOut("slow");
    });
    $("#JZShi").focus(function () {
        $("#DJZShi").fadeIn("slow").css("color", "red").html("（父母、兄弟、姐妹及子女的健康状况，有无与患者类似的疾病；如已死亡，应记录死亡的原因及年龄）");
    }).blur(function () {
        $("#DJZShi").fadeOut("slow");
    }); 

    $("#TGJCha_YBZK").focus(function () {
        $("#DTGJCha_YBZK").fadeIn("slow").css("color", "red").html("发育（正常、异常），营养（良好、中等、不良、肥胖），神志（清晰、淡漠、模糊、昏睡、谵妄、昏迷），体位（自主、被动、强迫），面荣与表情（安静、忧虑、烦躁、痛苦，急、慢性病容或特殊面容），检查能否合作");
    }).blur(function () {
        $("#DTGJCha_YBZK").fadeOut("slow");
    });
    $("#TGJCha_PFNM").focus(function () {
        $("#DTGJCha_PFNM").fadeIn("slow").css("color", "red").html("颜色（正常、潮红、苍白、发绀、黄染、色素沉着），温度，湿度，弹性，有无水肿、皮疹、瘀点、紫癜、皮下结节、肿块、蜘蛛痣、肝掌、溃疡和瘢痕，毛发的生长及分布");
    }).blur(function () {
        $("#DTGJCha_PFNM").fadeOut("slow");
    });
    $("#TGJCha_LBJ").focus(function () {
        $("#DTGJCha_LBJ").fadeIn("slow").css("color", "red").html("全身或局部淋巴结有无肿大（部位、大小、数目、硬度、活动度或粘连情况，局部皮肤有无红肿、波动、压痛、瘘管、瘢痕等）");
    }).blur(function () {
        $("#DTGJCha_LBJ").fadeOut("slow");
    });
    $("#TGJCha_TB_TL").focus(function () {
        $("#DTGJCha_TB_TL").fadeIn("slow").css("color", "red").html("大小、形状，有无肿块、压痛、瘢痕，头发（量、色泽、分布）");
    }).blur(function () {
        $("#DTGJCha_TB_TL").fadeOut("slow");
    });

    $("#TGJCha_TB_Y").focus(function () {
        $("#DTGJCha_TB_Y").fadeIn("slow").css("color", "red").html("眉毛（脱落、稀疏），睫毛（倒睫），眼睑（水肿、运动、下垂），眼球（凸出、凹陷、运动、斜视、震颤），结膜（充血、水肿、苍白、出血、滤泡），巩膜（黄染），角膜（云翳、白班、软化、溃疡、瘢痕、反射、色素环），瞳孔（大小、形态、对称或不对称、对光反射及调节与辐辏反射）");
    }).blur(function () {
        $("#DTGJCha_TB_Y").fadeOut("slow");
    });
    $("#TGJCha_TB_E").focus(function () {
        $("#DTGJCha_TB_E").fadeIn("slow").css("color", "red").html("有无畸形、分泌物、乳突压痛，听力");
    }).blur(function () {
        $("#DTGJCha_TB_E").fadeOut("slow");
    });
    $("#TGJCha_TB_B").focus(function () {
        $("#DTGJCha_TB_B").fadeIn("slow").css("color", "red").html("有无畸形、鼻翼扇动、分泌物、出血、阻塞，有无鼻中隔偏曲或穿孔和鼻窦压痛等");
    }).blur(function () {
        $("#DTGJCha_TB_B").fadeOut("slow");
    });
    $("#TGJCha_TB_KQ").focus(function () {
        $("#DTGJCha_TB_KQ").fadeIn("slow").css("color", "red").html("气味，有无张口呼吸，唇（畸形、颜色、疱疹、皲裂、溃疡、色素沉着），牙齿（龋齿、缺齿、义齿、残根，斑釉齿，注明位置），牙龈（色泽、肿胀、溃疡、溢脓、出血、铅线），舌（形态、舌质、舌苔、溃疡、运动、震颤、偏斜）,颊粘膜（发疹、出血点、溃疡、色素沉着），咽（色泽、分泌物、反射、腭垂位置），扁桃体（大小、充血、分泌物、假膜），喉（发音清晰、嘶哑、喘鸣、失音）");
    }).blur(function () {
        $("#DTGJCha_TB_KQ").fadeOut("slow");
    });
    $("#TGJCha_JB").focus(function () {
        $("#DTGJCha_JB").fadeIn("slow").css("color", "red").html("对称，强直，有无静脉怒张、肝颈静脉回流征、颈动脉异常搏动，器官位置，甲状腺（大小、硬度、压痛、结节、震颤、血管杂音）");
    }).blur(function () {
        $("#DTGJCha_JB").fadeOut("slow");
    });
    $("#TGJCha_XB").focus(function () {
        $("#DTGJCha_XB").fadeIn("slow").css("color", "red").html("胸廓（对称、畸形，有无局部隆起或塌陷、压痛），呼吸（频率、节律、深度），乳房（大小，乳头，有无红肿、压痛、肿块和分泌物），胸壁有无静脉曲张、皮下气肿等");
    }).blur(function () {
        $("#DTGJCha_XB").fadeOut("slow");
    });

    $("#TGJCha_F_SZ").focus(function () {
        $("#DTGJCha_F_SZ").fadeIn("slow").css("color", "red").html("呼吸运动（两侧对比），呼吸类型，有无肋间隙增大或变窄");
    }).blur(function () {
        $("#DTGJCha_F_SZ").fadeOut("slow");
    });
    $("#TGJCha_F_CZ").focus(function () {
        $("#DTGJCha_F_CZ").fadeIn("slow").css("color", "red").html("呼吸活动度、语颤（两侧对比），有无胸膜摩擦感、皮下捻发感等");
    }).blur(function () {
        $("#DTGJCha_F_CZ").fadeOut("slow");
    });
    $("#TGJCha_F_KZ").focus(function () {
        $("#DTGJCha_F_KZ").fadeIn("slow").css("color", "red").html("叩诊音（清音、过清音、浊音、实音、鼓音及其部位）。肺下界及肺下界移动度");
    }).blur(function () {
        $("#DTGJCha_F_KZ").fadeOut("slow");
    });
    $("#TGJCha_F_TZ").focus(function () {
        $("#DTGJCha_F_TZ").fadeIn("slow").css("color", "red").html("呼吸音（性质、强弱，异常呼吸音及其部位），有无干、湿啰音和胸膜摩擦音。语音传导（增强、减弱、消失）等");
    }).blur(function () {
        $("#DTGJCha_F_TZ").fadeOut("slow");
    });
    $("#TGJCha_X_SZ").focus(function () {
        $("#DTGJCha_X_SZ").fadeIn("slow").css("color", "red").html("心前区隆起，心尖搏动或心脏搏动位置，范围和强度");
    }).blur(function () {
        $("#DTGJCha_X_SZ").fadeOut("slow");
    });
    $("#TGJCha_X_CZ").focus(function () {
        $("#DTGJCha_X_CZ").fadeIn("slow").css("color", "red").html("心尖搏动的性质及位置，有无震颤（部位、期间）和摩擦感");
    }).blur(function () {
        $("#DTGJCha_X_CZ").fadeOut("slow");
    });
    $("#TGJCha_X_KZ").focus(function () {
        $("#DTGJCha_X_KZ").fadeIn("slow").css("color", "red").html("心脏左、右浊音界。可用左、右第2、3、4、5肋间距正中线的距离（cm）表示，须注明左锁骨中线距前正中线的距离（cm）");
    }).blur(function () {
        $("#DTGJCha_X_KZ").fadeOut("slow");
    });
    $("#TGJCha_X_TZ").focus(function () {
        $("#DTGJCha_X_TZ").fadeIn("slow").css("color", "red").html("心率，心律，心音的强弱，P<sub>2</sub>和A<sub>2</sub>）强度的比较，有无心音分裂、额外心音、杂音（部位、性质、收缩期货舒张期，连续性、强度、传导方向以及运动、体位和呼吸的关系；收缩期杂音强度用6级分法，如描述3级收缩期杂音，应写作“3/6级收缩期杂音”；舒张期杂音分为轻、中、重三度）和心包摩擦音等");
    }).blur(function () {
        $("#DTGJCha_X_TZ").fadeOut("slow");
    });
    $("#TGJCha_NDM").focus(function () {
        $("#DTGJCha_NDM").fadeIn("slow").css("color", "red").html("脉搏频率，节律（规则、不规则、脉搏短绌），有无奇脉等，搏动强度，动脉壁弹性，紧张度");
    }).blur(function () {
        $("#DTGJCha_NDM").fadeOut("slow");
    });
    $("#TGJCha_ZWXG").focus(function () {
        $("#DTGJCha_ZWXG").fadeIn("slow").css("color", "red").html("有无毛细血管搏动、射枪音、水冲脉和动脉异常搏动");
    }).blur(function () {
        $("#DTGJCha_ZWXG").fadeOut("slow");
    });

    $("#TGJCha_FB_FW").focus(function () {
        $("#DTGJCha_FB_FW").fadeIn("slow").css("color", "red").html("腹水或腹部包块等疾病时测量");
    }).blur(function () {
        $("#DTGJCha_FB_FW").fadeOut("slow");
    });
    $("#TGJCha_FB_SZ").focus(function () {
        $("#DTGJCha_FB_SZ").fadeIn("slow").css("color", "red").html("形状（对称、平坦、膨隆、凹陷），呼吸运动，肠胃蠕动波，有无皮疹、色素、条纹、瘢痕、腹壁静脉曲张（及其血流方向），疝和局部隆起（器官或包块）的部位、大小、轮廓，腹部体毛");
    }).blur(function () {
        $("#DTGJCha_FB_SZ").fadeOut("slow");
    });
    $("#TGJCha_FB_CZ").focus(function () {
        $("#TGJCha_FB_CZ").fadeIn("slow").css("color", "red").html("腹壁紧张度，有无压痛、反跳痛、液波震颤、肿块（部位、大小、形状、硬度、压痛、移动度、表面情况、搏动）");
    }).blur(function () {
        $("#TGJCha_FB_CZ").fadeOut("slow");
    });
    $("#TGJCha_FB_GZ").focus(function () {
        $("#DTGJCha_FB_GZ").fadeIn("slow").css("color", "red").html("大小（右叶以右锁骨中线肋下缘，左叶以前正中线剑突下至肝下缘多少厘米表示），质地（Ⅰ度：软；Ⅱ度：韧；Ⅲ度：硬），表面（光滑度），边缘，有无结节、压痛和搏动等");
    }).blur(function () {
        $("#DTGJCha_FB_GZ").fadeOut("slow");
    });
    $("#TGJCha_FB_DN").focus(function () {
        $("#DTGJCha_FB_DN").fadeIn("slow").css("color", "red").html("大小、形态，有无压痛、Murphy征");
    }).blur(function () {
        $("#DTGJCha_FB_DN").fadeOut("slow");
    });

    $("#TGJCha_FB_PZ").focus(function () {
        $("#DTGJCha_FB_PZ").fadeIn("slow").css("color", "red").html("大小，质地，表面，边缘，移动度，有无压痛摩擦感，脾脏明显肿大时以二线测量法表示");
    }).blur(function () {
        $("#DTGJCha_FB_PZ").fadeOut("slow");
    });

    $("#TGJCha_FB_ShenZ").focus(function () {
        $("#DTGJCha_FB_ShenZ").fadeIn("slow").css("color", "red").html("大小、形态、硬度、移动度，有无压痛");
    }).blur(function () {
        $("#DTGJCha_FB_ShenZ").fadeOut("slow");
    });
    $("#TGJCha_FB_PG").focus(function () {
        $("#DTGJCha_FB_PG").fadeIn("slow").css("color", "red").html("膨胀、肾及输尿管压痛点");
    }).blur(function () {
        $("#DTGJCha_FB_PG").fadeOut("slow");
    });
    $("#TGJCha_FB_KZ").focus(function () {
        $("#DTGJCha_FB_KZ").fadeIn("slow").css("color", "red").html("肝上线在第几肋间，干浊音界（缩小、消失），肝区叩击痛，有无移动性浊音、高度鼓音、肾区叩击痛等");
    }).blur(function () {
        $("#DTGJCha_FB_KZ").fadeOut("slow");
    });

    $("#TGJCha_FB_TZ").focus(function () {
        $("#DTGJCha_FB_TZ").fadeIn("slow").css("color", "red").html("肠鸣音（正常、增强、减弱、消失、金属音），有无振水音和血管杂音等");
    }).blur(function () {
        $("#DTGJCha_FB_TZ").fadeOut("slow");
    });
    $("#TGJCha_GMZC").focus(function () {
        $("#DTGJCha_GMZC").fadeIn("slow").css("color", "red").html("视病情需要检查。有无肿块、裂隙、创面。直肠指诊（括约肌紧张度，有无狭窄、肿块、触痛、指套染血；前列腺大小、硬度，有无结节及压痛等）");
    }).blur(function () {
        $("#DTGJCha_GMZC").fadeOut("slow");
    });
    $("#TGJCha_WSZQ").focus(function () {
        $("#DTGJCha_WSZQ").fadeIn("slow").css("color", "red").html("根据病情需要做相应检查。<br>男性：包皮，阴囊，睾丸，精索，有无发育畸形、鞘膜积液<br>女性：检查时必须有女医护人员在场，必要时请妇科医师检查。包括外生殖器（阴毛、大小阴唇、阴蒂、阴阜）和内生殖器（阴道、子宫、输卵管、卵巢）");
    }).blur(function () {
        $("#DTGJCha_WSZQ").fadeOut("slow");
    });
    $("#TGJCha_JZ").focus(function () {
        $("#DTGJCha_JZ").fadeIn("slow").css("color", "red").html("活动度，有无畸形（侧凸、前凸、后凸）、压痛和叩击痛等");
    }).blur(function () {
        $("#DTGJCha_JZ").fadeOut("slow");
    });
    $("#TGJCha_SZ").focus(function () {
        $("#DTGJCha_SZ").fadeIn("slow").css("color", "red").html("有无畸形，杵状指（趾），静脉曲张，骨折及关节红肿、疼痛、压痛、积液、脱臼、强直、畸形，水肿，肌肉萎缩，肌张力变化或肢体瘫痪等");
    }).blur(function () {
        $("#DTGJCha_SZ").fadeOut("slow");
    });
    $("#TGJCha_SJFS_SLFS").focus(function () {
        $("#DTGJCha_SJFS_SLFS").fadeIn("slow").css("color", "red").html("浅反射（角膜反射、腹壁反射、提睾反射）。深反射（肱二头肌、肱三头肌及膝腱、跟腱反射）");
    }).blur(function () {
        $("#DTGJCha_SJFS_SLFS").fadeOut("slow");
    });
    $("#TGJCha_SJFS_BLFS").focus(function () {
        $("#DTGJCha_SJFS_BLFS").fadeIn("slow").css("color", "red").html("Babinski征、Oppenheim征、Gordon征、Chaddock征、Hoffmann征");
    }).blur(function () {
        $("#DTGJCha_SJFS_BLFS").fadeOut("slow");
    });
    $("#TGJCha_SJFS_NMCJ").focus(function () {
        $("#DTGJCha_SJFS_NMCJ").fadeIn("slow").css("color", "red").html("颈项强直、Kernig征，Brudzinski征");
    }).blur(function () {
        $("#DTGJCha_SJFS_NMCJ").fadeOut("slow");
    });
    $("#TGJCha_SJFS_QT").focus(function () {
        $("#DTGJCha_SJFS_QT").fadeIn("slow").css("color", "red").html("必要时做运动、感觉等及神经系统其它特殊检查");
    }).blur(function () {
        $("#DTGJCha_SJFS_QT").fadeOut("slow");
    });
    $("#TGJCha_ZKQK").focus(function () {
        $("#DTGJCha_ZKQK").fadeIn("slow").css("color", "red").html("外科、耳鼻咽喉科、眼科、妇产科、口腔科、介入放射科、神经精神等专科需写“外科情况”、“妇科检查”......主要记录与本专科有关的体征，前面体格检查中的相应项目不必重复书写，只写“见xx科情况”");
    }).blur(function () {
        $("#DTGJCha_ZKQK").fadeOut("slow");
    });
}
//加载姓名 基地 科室 指导医师
function loadInfo() {
    $("#DeptCode option:not(:first)").remove();
    $("#TeachersName option:not(:first)").remove();
    $.ajax({
        cache: false,
        asycn: true,
        type: "get",
        url: '/Common/GetInfo',
        dataType: "text",
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.msg == "0") {
                alert("请完善个人基本信息");
                return false;
            } else {
                var personalJson = jsonArr.personalInfo;
                var deptJson = jsonArr.deptInfo;
                $("#StudentsName").val(personalJson.Name);
                $("#StudentsRealName").val(personalJson.RealName);
                $("#TrainingBaseCode").val(personalJson.TrainingBaseCode);
                $("#TrainingBaseName").val(personalJson.TrainingBaseName);
                $("#ProfessionalBaseCode").val(personalJson.ProfessionalBaseCode);
                $("#ProfessionalBaseName").val(personalJson.ProfessionalBaseName);
                $("#Writor").val(personalJson.RealName);
                for (var i = 0; i < deptJson.length; i++) {
                    $("#DeptCode").append("<option value=" + deptJson[i].dept_code + ">" + deptJson[i].dept_name + "</option>");
                }
            }
        },
        error: function () {
            alert("系统繁忙，请联系管理员")
        }
    });

    $("#DeptCode").change(function () {
        $("#TeachersName option:not(:first)").remove();

        $.ajax({
            cache: false,
            type: "get",
            url: '/Common/GetTeachers',
            dataType: "text",
            data: { TrainingBaseCode: $("#TrainingBaseCode").val(), DeptCode: $("#DeptCode").val() },
            success: function (data) {
                var jsonArr = eval("(" + data + ")");
                if (jsonArr.msg == "0") {
                    alert("尚无指导医师信息，请联系管理员");
                    return false;
                } else {
                    var Teachers = jsonArr.teachersInfo;
                    for (var i = 0; i < Teachers.length; i++) {
                        $("#TeachersName").append("<option value=" + Teachers[i].name + ">" + Teachers[i].real_name + "</option>");
                    }
                }
                if ($("#DeptCode").val() == "") {
                    $("#DeptName").val("");
                    $("#TeacherName").val("");
                } else {
                    $("#DeptName").val($("#DeptCode").find("option:selected").text());
                }
            },
            error: function () {
                alert("系统繁忙，请联系管理员");
            }
        });
    });

    $("#TeachersName").change(function () {
        if ($("#TeachersName").val == "") {
            $("#TeachersRealName").val("");
        } else {
            $("#TeachersRealName").val($("#TeachersName").find("option:selected").text());
        }
    });
    
}


function loadInfo2() {
    $("#DeptCode option:not(:first)").remove();
    $("#TeacherId option:not(:first)").remove();
    $.ajax({
        cache: false,
        asycn: true,
        type: "get",
        url: '/Common/GetInfo',
        dataType: "text",
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.msg == "0") {
                alert("请完善个人基本信息");
                return false;
            } else {
                var personalJson = jsonArr.personalInfo;
                var deptJson = jsonArr.deptInfo;
                $("#StudentsName").val(personalJson.Name);
                $("#StudentsRealName").val(personalJson.RealName);
                $("#TrainingBaseCode").val(personalJson.TrainingBaseCode);
                $("#TrainingBaseName").val(personalJson.TrainingBaseName);
                $("#ProfessionalBaseCode").val(personalJson.ProfessionalBaseCode);
                $("#ProfessionalBaseName").val(personalJson.ProfessionalBaseName);
                $("#Writor").val(personalJson.RealName);
                for (var i = 0; i < deptJson.length; i++) {
                    $("#DeptCode").append("<option value=" + deptJson[i].dept_code + ">" + deptJson[i].dept_name + "</option>");
                }
            }
        },
        error: function () {
            alert("系统繁忙，请联系管理员")
        }
    });

    $("#DeptCode").change(function () {
        $("#TeacherId option:not(:first)").remove();

        $.ajax({
            cache: false,
            type: "get",
            url: '/Common/GetTeachers',
            dataType: "text",
            data: { TrainingBaseCode: $("#TrainingBaseCode").val(), DeptCode: $("#DeptCode").val() },
            success: function (data) {
                var jsonArr = eval("(" + data + ")");
                if (jsonArr.msg == "0") {
                    alert("尚无指导医师信息，请联系管理员");
                    return false;
                } else {
                    var Teachers = jsonArr.teachersInfo;
                    for (var i = 0; i < Teachers.length; i++) {
                        $("#TeacherId").append("<option value=" + Teachers[i].name + ">" + Teachers[i].real_name + "</option>");
                    }
                }
                if ($("#DeptCode").val() == "") {
                    $("#DeptName").val("");
                    $("#TeacherId").val("");
                } else {
                    $("#DeptName").val($("#DeptCode").find("option:selected").text());
                }
            },
            error: function () {
                alert("系统繁忙，请联系管理员");
            }
        });
    });

    $("#TeacherId").change(function () {
        if ($("#TeacherId").val == "") {
            $("#TeacherName").val("");
        } else {
            $("#TeacherName").val($("#TeacherId").find("option:selected").text());
        }
    });

}
//加载省市县
function loadProvinceCityArea(provinceId, cityId, areaId, provinceHidden, cityHidden, areaHidden) {
    $.ajax({
        cache: false,
        type: "get",
        url: '/Common/Province',
        dataType: "text",
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr !=null) {
                for (var i = 0; i < jsonArr.length; i++) {
                    $(provinceId).append("<option Value=" + jsonArr[i].provinceid + ">" + jsonArr[i].province + "</option>");
                }
            }
            $(provinceHidden).val("");
            $(cityHidden).val("");
            $(areaHidden).val("");
        },
        error: function () {
            alert("系统繁忙，请联系管理员");
        }
    });
    $(provinceId).change(function () {

        $(cityId + " " + "option:gt(0)").remove();
        $(areaId + " " + "option:gt(0)").remove();
        $.post('/Common/City', { "father": $(provinceId).val() }, function (data) {
            var jsonArr = data;
            if (jsonArr != null) {
                for (var i = 0; i < jsonArr.length; i++) {

                    $(cityId).append("<option Value=" + jsonArr[i].cityid + ">" + jsonArr[i].city + "</option>");

                }
            }

        });
        var pro_name = $(provinceId).find("option:selected").text();
        var pro_code = $(provinceId).val();
        if (pro_code == "") {
            $(provinceHidden).val("");
            return;
        } else {
            $(provinceHidden).val(pro_name);
        }

    });
    $(cityId).change(function () {
        $(areaId + " " + "option:gt(0)").remove();
        $.post('/Common/Area', { "father": $(cityId).val() }, function (data) {
            var jsonArr = data;
            if (jsonArr != null) {
                for (var i = 0; i < jsonArr.length; i++) {
                    $(areaId).append("<option Value=" + jsonArr[i].areaid + ">" + jsonArr[i].area + "</option>");

                }
            }
        });
        var cit_name = $(cityId).find("option:selected").text();
        var cit_code = $(cityId).val();
        if (cit_code == "") {
            $(cityHidden).val("");
        } else {
            $(cityHidden).val(cit_name);
        }
    });

    $(areaId).change(function () {
        var are_name = $(areaId).find("option:selected").text();
        var are_code = $(areaId).val();
        if (are_code == "") {
            $(areaHidden).val("");
        } else {
            $(areaHidden).val(are_name);
        }
    });

}



function loadUpdateCA(pCode, cityId, cCdoe, areaId, aCode) {
    $.post("/Common/City", { "father": pCode }, function (data) {
        var jsonArr = data;
        if (jsonArr != "") {
            for (var i = 0; i < jsonArr.length; i++) {
                if (jsonArr[i].cityid == cCdoe) {
                    $(cityId).append("<option selected='selected' Value=" + jsonArr[i].cityid + ">" + jsonArr[i].city + "</option>");
                } else {
                    $(cityId).append("<option Value=" + jsonArr[i].cityid + ">" + jsonArr[i].city + "</option>");
                }

            }
        }

    });
    $.post("/Common/Area", { "father": cCdoe }, function (data) {
        var jsonArr = data;
        if (jsonArr != "") {
            for (var i = 0; i < jsonArr.length; i++) {
                if (jsonArr[i].areaid == aCode) {
                    $(areaId).append("<option selected='selected' Value=" + jsonArr[i].areaid + ">" + jsonArr[i].area + "</option>");
                } else {
                    $(areaId).append("<option Value=" + jsonArr[i].areaid + ">" + jsonArr[i].area + "</option>");
                }

            }
        }
    });

}

function loadTeacher(trainingBaseCode, deptCode, teachersName) {
    $("#TeachersName option:not(:first)").remove();

    $.ajax({
        cache: false,
        type: "get",
        url: "/Common/GetTeachers",
        dataType: "text",
        data: { TrainingBaseCode: trainingBaseCode, DeptCode: deptCode },
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.msg == "0") {
                alert("尚无指导医师信息，请联系管理员");
                return false;
            } else {
                var Teachers = jsonArr.teachersInfo;
                for (var i = 0; i < Teachers.length; i++) {
                    if (Teachers[i].name == teachersName) {
                        $("#TeachersName").append("<option selected='selected' value=" + Teachers[i].name + ">" + Teachers[i].real_name + "</option>");
                    } else {
                        $("#TeachersName").append("<option value=" + Teachers[i].name + ">" + Teachers[i].real_name + "</option>");
                    }
                }
            }
        },
        error: function () {
            alert("系统繁忙，请联系管理员");
        }
    });

}

function loadTeacher2(trainingBaseCode, deptCode, teachersName) {
    $("#TeacherId option:not(:first)").remove();

    $.ajax({
        cache: false,
        type: "get",
        url: "/Common/GetTeachers",
        dataType: "text",
        data: { TrainingBaseCode: trainingBaseCode, DeptCode: deptCode },
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.msg == "0") {
                alert("尚无指导医师信息，请联系管理员");
                return false;
            } else {
                var Teachers = jsonArr.teachersInfo;
                for (var i = 0; i < Teachers.length; i++) {
                    if (Teachers[i].name == teachersName) {
                        $("#TeacherId").append("<option selected='selected' value=" + Teachers[i].name + ">" + Teachers[i].real_name + "</option>");
                    } else {
                        $("#TeacherId").append("<option value=" + Teachers[i].name + ">" + Teachers[i].real_name + "</option>");
                    }
                }
            }
        },
        error: function () {
            alert("系统繁忙，请联系管理员");
        }
    });

}

