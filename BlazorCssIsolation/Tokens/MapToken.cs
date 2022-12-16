﻿namespace BlazorCssIsolation.Tokens;

public partial record MapToken : TokenBase
{
    //public MapToken(
    //    SeedToken seedToken,
    //    ColorPalettes colorPalettes,
    //    ColorMapToken colorMapToken,
    //    SizeMapToken sizeMapToken,
    //    CommonMapToken commonMapToken,
    //    FontMapToken fontMapToken,
    //    HeightMapToken heightMapToken) : this(
    //        blue: seedToken.Blue,
    //        blue1: colorPalettes.Blue1,
    //        blue10: colorPalettes.Blue10,
    //        blue2: colorPalettes.Blue2,
    //        blue3: colorPalettes.Blue3,
    //        blue4: colorPalettes.Blue4,
    //        blue5: colorPalettes.Blue5,
    //        blue6: colorPalettes.Blue6,
    //        blue7: colorPalettes.Blue7,
    //        blue8: colorPalettes.Blue8,
    //        blue9: colorPalettes.Blue9,
    //        borderRadius: seedToken.BorderRadius,
    //        borderRadiusLG: commonMapToken.BorderRadiusLG,
    //        borderRadiusSM: commonMapToken.BorderRadiusSM,
    //        borderRadiusXS: commonMapToken.BorderRadiusXS,
    //        colorBgBase: seedToken.ColorBgBase,
    //        colorBgContainer: colorMapToken.ColorBgContainer,
    //        colorBgElevated: colorMapToken.ColorBgElevated,
    //        colorBgLayout: colorMapToken.ColorBgLayout,
    //        colorBgMask: colorMapToken.ColorBgMask,
    //        colorBgSpotlight: colorMapToken.ColorBgSpotlight,
    //        colorBorder: colorMapToken.ColorBorder,
    //        colorBorderSecondary: colorMapToken.ColorBorderSecondary,
    //        colorError: colorMapToken.ColorError,
    //        colorErrorActive: colorMapToken.ColorErrorActive,
    //        colorErrorBg: colorMapToken.ColorErrorBg,
    //        colorErrorBgHover: colorMapToken.ColorErrorBgHover,
    //        colorErrorBorder: colorMapToken.ColorErrorBorder,
    //        colorErrorBorderHover: colorMapToken.ColorErrorBorderHover,
    //        colorErrorHover: colorMapToken.ColorErrorHover,
    //        colorErrorText: colorMapToken.ColorErrorText,
    //        colorErrorTextActive: colorMapToken.ColorErrorTextActive,
    //        colorErrorTextHover: colorMapToken.ColorErrorTextHover,
    //        colorFill: colorMapToken.ColorFill,
    //        colorFillQuaternary: colorMapToken.ColorFillQuaternary,
    //        colorFillSecondary: colorMapToken.ColorFillSecondary,
    //        colorFillTertiary: colorMapToken.ColorFillTertiary,
    //        colorInfo: colorMapToken.ColorInfo,
    //        colorInfoActive: colorMapToken.ColorInfoActive,
    //        colorInfoBg: colorMapToken.ColorInfoBg,
    //        colorInfoBgHover: colorMapToken.ColorInfoBgHover,
    //        colorInfoBorder: colorMapToken.ColorInfoBorder,
    //        colorInfoBorderHover: colorMapToken.ColorInfoBorderHover,
    //        colorInfoHover: colorMapToken.ColorInfoHover,
    //        colorInfoText: colorMapToken.ColorInfoText,
    //        colorInfoTextActive: colorMapToken.ColorInfoTextActive,
    //        colorInfoTextHover: colorMapToken.ColorInfoTextHover,
    //        colorPrimary: colorMapToken.ColorPrimary,
    //        colorPrimaryActive: colorMapToken.ColorPrimaryActive,
    //        colorPrimaryBg: colorMapToken.ColorPrimaryBg,
    //        colorPrimaryBgHover: colorMapToken.ColorPrimaryBgHover,
    //        colorPrimaryBorder: colorMapToken.ColorPrimaryBorder,
    //        colorPrimaryBorderHover: colorMapToken.ColorPrimaryBorderHover,
    //        colorPrimaryHover: colorMapToken.ColorPrimaryHover,
    //        colorPrimaryText: colorMapToken.ColorPrimaryText,
    //        colorPrimaryTextActive: colorMapToken.ColorPrimaryTextActive,
    //        colorPrimaryTextHover: colorMapToken.ColorPrimaryTextHover,
    //        colorSuccess: colorMapToken.ColorSuccess,
    //        colorSuccessActive: colorMapToken.ColorSuccessActive,
    //        colorSuccessBg: colorMapToken.ColorSuccessBg,
    //        colorSuccessBgHover: colorMapToken.ColorSuccessBgHover,
    //        colorSuccessBorder: colorMapToken.ColorSuccessBorder,
    //        colorSuccessBorderHover: colorMapToken.ColorSuccessBorderHover,
    //        colorSuccessHover: colorMapToken.ColorSuccessHover,
    //        colorSuccessText: colorMapToken.ColorSuccessText,
    //        colorSuccessTextActive: colorMapToken.ColorSuccessTextActive,
    //        colorSuccessTextHover: colorMapToken.ColorSuccessTextHover,
    //        colorText: colorMapToken.ColorText,
    //        colorTextBase: seedToken.ColorTextBase,
    //        colorTextQuaternary: colorMapToken.ColorTextQuaternary,
    //        colorTextSecondary: colorMapToken.ColorTextSecondary,
    //        colorTextTertiary: colorMapToken.ColorTextTertiary,
    //        colorWarning: colorMapToken.ColorWarning,
    //        colorWarningActive: colorMapToken.ColorWarningActive,
    //        colorWarningBg: colorMapToken.ColorWarningBg,
    //        colorWarningBgHover: colorMapToken.ColorWarningBgHover,
    //        colorWarningBorder: colorMapToken.ColorWarningBorder,
    //        colorWarningBorderHover: colorMapToken.ColorWarningBorderHover,
    //        colorWarningHover: colorMapToken.ColorWarningHover,
    //        colorWarningText: colorMapToken.ColorWarningText,
    //        colorWarningTextActive: colorMapToken.ColorWarningTextActive,
    //        colorWarningTextHover: colorMapToken.ColorWarningTextHover,
    //        colorWhite: colorMapToken.ColorWhite,
    //        controlHeight: seedToken.ControlHeight,
    //        cyan: seedToken.Cyan,
    //        cyan1: colorPalettes.Cyan1,
    //        cyan10: colorPalettes.Cyan10,
    //        cyan2: colorPalettes.Cyan2,
    //        cyan3: colorPalettes.Cyan3,
    //        cyan4: colorPalettes.Cyan4,
    //        cyan5: colorPalettes.Cyan5,
    //        cyan6: colorPalettes.Cyan6,
    //        cyan7: colorPalettes.Cyan7,
    //        cyan8: colorPalettes.Cyan8,
    //        cyan9: colorPalettes.Cyan9,
    //        fontFamily: seedToken.FontFamily,
    //        fontSize: seedToken.FontSize,
    //        geekblue: seedToken.Geekblue,
    //        geekblue1: colorPalettes.Geekblue1,
    //        geekblue10: colorPalettes.Geekblue10,
    //        geekblue2: colorPalettes.Geekblue2,
    //        geekblue3: colorPalettes.Geekblue3,
    //        geekblue4: colorPalettes.Geekblue4,
    //        geekblue5: colorPalettes.Geekblue5,
    //        geekblue6: colorPalettes.Geekblue6,
    //        geekblue7: colorPalettes.Geekblue7,
    //        geekblue8: colorPalettes.Geekblue8,
    //        geekblue9: colorPalettes.Geekblue9,
    //        gold: seedToken.Gold,
    //        gold1: colorPalettes.Gold1,
    //        gold10: colorPalettes.Gold10,
    //        gold2: colorPalettes.Gold2,
    //        gold3: colorPalettes.Gold3,
    //        gold4: colorPalettes.Gold4,
    //        gold5: colorPalettes.Gold5,
    //        gold6: colorPalettes.Gold6,
    //        gold7: colorPalettes.Gold7,
    //        gold8: colorPalettes.Gold8,
    //        gold9: colorPalettes.Gold9,
    //        green: seedToken.Green,
    //        green1: colorPalettes.Green1,
    //        green10: colorPalettes.Green10,
    //        green2: colorPalettes.Green2,
    //        green3: colorPalettes.Green3,
    //        green4: colorPalettes.Green4,
    //        green5: colorPalettes.Green5,
    //        green6: colorPalettes.Green6,
    //        green7: colorPalettes.Green7,
    //        green8: colorPalettes.Green8,
    //        green9: colorPalettes.Green9,
    //        lime: seedToken.Lime,
    //        lime1: colorPalettes.Lime1,
    //        lime10: colorPalettes.Lime10,
    //        lime2: colorPalettes.Lime2,
    //        lime3: colorPalettes.Lime3,
    //        lime4: colorPalettes.Lime4,
    //        lime5: colorPalettes.Lime5,
    //        lime6: colorPalettes.Lime6,
    //        lime7: colorPalettes.Lime7,
    //        lime8: colorPalettes.Lime8,
    //        lime9: colorPalettes.Lime9,
    //        lineType: seedToken.LineType,
    //        lineWidth: seedToken.LineWidth,
    //        lineWidthBold: commonMapToken.LineWidthBold,
    //        magenta: seedToken.Magenta,
    //        magenta1: colorPalettes.Magenta1,
    //        magenta10: colorPalettes.Magenta10,
    //        magenta2: colorPalettes.Magenta2,
    //        magenta3: colorPalettes.Magenta3,
    //        magenta4: colorPalettes.Magenta4,
    //        magenta5: colorPalettes.Magenta5,
    //        magenta6: colorPalettes.Magenta6,
    //        magenta7: colorPalettes.Magenta7,
    //        magenta8: colorPalettes.Magenta8,
    //        magenta9: colorPalettes.Magenta9,
    //        motionDurationFast: commonMapToken.MotionDurationFast,
    //        motionDurationMid: commonMapToken.MotionDurationMid,
    //        motionDurationSlow: commonMapToken.MotionDurationSlow,
    //        motionUnit: seedToken.MotionUnit,
    //        orange: seedToken.Orange,
    //        orange1: colorPalettes.Orange1,
    //        orange10: colorPalettes.Orange10,
    //        orange2: colorPalettes.Orange2,
    //        orange3: colorPalettes.Orange3,
    //        orange4: colorPalettes.Orange4,
    //        orange5: colorPalettes.Orange5,
    //        orange6: colorPalettes.Orange6,
    //        orange7: colorPalettes.Orange7,
    //        orange8: colorPalettes.Orange8,
    //        orange9: colorPalettes.Orange9,
    //        pink: seedToken.Pink,
    //        pink1: colorPalettes.Pink1,
    //        pink10: colorPalettes.Pink10,
    //        pink2: colorPalettes.Pink2,
    //        pink3: colorPalettes.Pink3,
    //        pink4: colorPalettes.Pink4,
    //        pink5: colorPalettes.Pink5,
    //        pink6: colorPalettes.Pink6,
    //        pink7: colorPalettes.Pink7,
    //        pink8: colorPalettes.Pink8,
    //        pink9: colorPalettes.Pink9,
    //        purple: seedToken.Purple,
    //        purple1: colorPalettes.Purple1,
    //        purple10: colorPalettes.Purple10,
    //        purple2: colorPalettes.Purple2,
    //        purple3: colorPalettes.Purple3,
    //        purple4: colorPalettes.Purple4,
    //        purple5: colorPalettes.Purple5,
    //        purple6: colorPalettes.Purple6,
    //        purple7: colorPalettes.Purple7,
    //        purple8: colorPalettes.Purple8,
    //        purple9: colorPalettes.Purple9,
    //        red: seedToken.Red,
    //        red1: colorPalettes.Red1,
    //        red10: colorPalettes.Red10,
    //        red2: colorPalettes.Red2,
    //        red3: colorPalettes.Red3,
    //        red4: colorPalettes.Red4,
    //        red5: colorPalettes.Red5,
    //        red6: colorPalettes.Red6,
    //        red7: colorPalettes.Red7,
    //        red8: colorPalettes.Red8,
    //        red9: colorPalettes.Red9,
    //        size: sizeMapToken.Size,
    //        sizeLG: sizeMapToken.SizeLG,
    //        sizeMD: sizeMapToken.SizeMD,
    //        sizeMS: sizeMapToken.SizeMS,
    //        sizeSM: sizeMapToken.SizeSM,
    //        sizeStep: seedToken.SizeStep,
    //        sizeUnit: seedToken.SizeUnit,
    //        sizeXL: sizeMapToken.SizeXL,
    //        sizeXS: sizeMapToken.SizeXS,
    //        sizeXXL: sizeMapToken.SizeXXL,
    //        sizeXXS: sizeMapToken.SizeXXS,
    //        volcano: seedToken.Volcano,
    //        volcano1: colorPalettes.Volcano1,
    //        volcano10: colorPalettes.Volcano10,
    //        volcano2: colorPalettes.Volcano2,
    //        volcano3: colorPalettes.Volcano3,
    //        volcano4: colorPalettes.Volcano4,
    //        volcano5: colorPalettes.Volcano5,
    //        volcano6: colorPalettes.Volcano6,
    //        volcano7: colorPalettes.Volcano7,
    //        volcano8: colorPalettes.Volcano8,
    //        volcano9: colorPalettes.Volcano9,
    //        wireframe: seedToken.Wireframe,
    //        yellow: seedToken.Yellow,
    //        yellow1: colorPalettes.Yellow1,
    //        yellow10: colorPalettes.Yellow10,
    //        yellow2: colorPalettes.Yellow2,
    //        yellow3: colorPalettes.Yellow3,
    //        yellow4: colorPalettes.Yellow4,
    //        yellow5: colorPalettes.Yellow5,
    //        yellow6: colorPalettes.Yellow6,
    //        yellow7: colorPalettes.Yellow7,
    //        yellow8: colorPalettes.Yellow8,
    //        yellow9: colorPalettes.Yellow9,
    //        zIndexBase: seedToken.ZIndexBase,
    //        zIndexPopupBase: seedToken.ZIndexPopupBase,
    //        fontSizeHeading1: fontMapToken.FontSizeHeading1,
    //        fontSizeHeading2: fontMapToken.FontSizeHeading2,
    //        fontSizeHeading3: fontMapToken.FontSizeHeading3,
    //        fontSizeHeading4: fontMapToken.FontSizeHeading4,
    //        fontSizeHeading5: fontMapToken.FontSizeHeading5,
    //        fontSizeLG: fontMapToken.FontSizeLG,
    //        fontSizeSM: fontMapToken.FontSizeSM,
    //        fontSizeXL: fontMapToken.FontSizeXL,
    //        lineHeight: 0,
    //        )
    //{
    //}
}
