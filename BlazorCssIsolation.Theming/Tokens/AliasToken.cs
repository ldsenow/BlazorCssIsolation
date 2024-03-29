﻿namespace BlazorCssIsolation.Theming.Tokens;

public partial record AliasToken : TokenBase
{
    const int screenXS = 480;
    const int screenSM = 576;
    const int screenMD = 768;
    const int screenLG = 992;
    const int screenXL = 1200;
    const int screenXXL = 1600;

    public AliasToken(
        SeedToken seedToken,
        ColorPalettes colorPalettes,
        ColorMapToken colorMapToken,
        SizeMapToken sizeMapToken,
        CommonMapToken commonMapToken,
        FontMapToken fontMapToken,
        HeightMapToken heightMapToken) : this(
            blue: seedToken.Blue,
            blue1: colorPalettes.Blue1,
            blue10: colorPalettes.Blue10,
            blue2: colorPalettes.Blue2,
            blue3: colorPalettes.Blue3,
            blue4: colorPalettes.Blue4,
            blue5: colorPalettes.Blue5,
            blue6: colorPalettes.Blue6,
            blue7: colorPalettes.Blue7,
            blue8: colorPalettes.Blue8,
            blue9: colorPalettes.Blue9,
            borderRadius: seedToken.BorderRadius,
            borderRadiusLG: commonMapToken.BorderRadiusLG,
            borderRadiusOuter: commonMapToken.BorderRadiusOuter,
            borderRadiusSM: commonMapToken.BorderRadiusSM,
            borderRadiusXS: commonMapToken.BorderRadiusXS,
            boxShadow: "0 1px 2px 0 rgba(0, 0, 0, 0.03), 0 1px 6px -1px rgba(0, 0, 0, 0.02), 0 2px 4px 0 rgba(0, 0, 0, 0.02)",
            boxShadowSecondary: "0 6px 16px 0 rgba(0, 0, 0, 0.08), 0 3px 6px -4px rgba(0, 0, 0, 0.12), 0 9px 28px 8px rgba(0, 0, 0, 0.05)",
            boxShadowTertiary: "0 1px 2px 0 rgba(0, 0, 0, 0.03), 0 1px 6px -1px rgba(0, 0, 0, 0.02), 0 2px 4px 0 rgba(0, 0, 0, 0.02)",
            colorBgBase: seedToken.ColorBgBase,
            colorBgContainer: colorMapToken.ColorBgContainer,
            colorBgContainerDisabled: colorMapToken.ColorFillTertiary,
            colorBgElevated: colorMapToken.ColorBgElevated,
            colorBgLayout: colorMapToken.ColorBgLayout,
            colorBgMask: colorMapToken.ColorBgMask,
            colorBgSpotlight: colorMapToken.ColorBgSpotlight,
            colorBgTextActive: colorMapToken.ColorFill,
            colorBgTextHover: colorMapToken.ColorFillSecondary,
            colorBorder: colorMapToken.ColorBorder,
            colorBorderBg: colorMapToken.ColorBgContainer,
            colorBorderSecondary: colorMapToken.ColorBorderSecondary,
            colorError: colorMapToken.ColorError,
            colorErrorActive: colorMapToken.ColorErrorActive,
            colorErrorBg: colorMapToken.ColorErrorBg,
            colorErrorBgHover: colorMapToken.ColorErrorBgHover,
            colorErrorBorder: colorMapToken.ColorErrorBorder,
            colorErrorBorderHover: colorMapToken.ColorErrorBorderHover,
            colorErrorHover: colorMapToken.ColorErrorHover,
            colorErrorOutline: new HEX(colorMapToken.ColorErrorBg).ClampAlpha(new HEX(colorMapToken.ColorBgContainer)).AsString(),
            colorErrorText: colorMapToken.ColorErrorText,
            colorErrorTextActive: colorMapToken.ColorErrorTextActive,
            colorErrorTextHover: colorMapToken.ColorErrorTextHover,
            colorFill: colorMapToken.ColorFill,
            colorFillAlter: colorMapToken.ColorFillQuaternary,
            colorFillContent: colorMapToken.ColorFillSecondary,
            colorFillContentHover: colorMapToken.ColorFill,
            colorFillQuaternary: colorMapToken.ColorFillQuaternary,
            colorFillSecondary: colorMapToken.ColorFillSecondary,
            colorFillTertiary: colorMapToken.ColorFillTertiary,
            colorHighlight: colorMapToken.ColorError,
            colorIcon: colorMapToken.ColorTextTertiary,
            colorIconHover: colorMapToken.ColorText,
            colorInfo: colorMapToken.ColorInfo,
            colorInfoActive: colorMapToken.ColorInfoActive,
            colorInfoBg: colorMapToken.ColorInfoBg,
            colorInfoBgHover: colorMapToken.ColorInfoBgHover,
            colorInfoBorder: colorMapToken.ColorInfoBorder,
            colorInfoBorderHover: colorMapToken.ColorInfoBorderHover,
            colorInfoHover: colorMapToken.ColorInfoHover,
            colorInfoText: colorMapToken.ColorInfoText,
            colorInfoTextActive: colorMapToken.ColorInfoTextActive,
            colorInfoTextHover: colorMapToken.ColorInfoTextHover,
            colorLink: colorMapToken.ColorInfoText,
            colorLinkActive: colorMapToken.ColorInfoActive,
            colorLinkHover: colorMapToken.ColorInfoHover,
            colorPrimary: colorMapToken.ColorPrimary,
            colorPrimaryActive: colorMapToken.ColorPrimaryActive,
            colorPrimaryBg: colorMapToken.ColorPrimaryBg,
            colorPrimaryBgHover: colorMapToken.ColorPrimaryBgHover,
            colorPrimaryBorder: colorMapToken.ColorPrimaryBorder,
            colorPrimaryBorderHover: colorMapToken.ColorPrimaryBorderHover,
            colorPrimaryHover: colorMapToken.ColorPrimaryHover,
            colorPrimaryText: colorMapToken.ColorPrimaryText,
            colorPrimaryTextActive: colorMapToken.ColorPrimaryTextActive,
            colorPrimaryTextHover: colorMapToken.ColorPrimaryTextHover,
            colorSplit: new HEX(colorMapToken.ColorBorderSecondary).ClampAlpha(new HEX(colorMapToken.ColorBgContainer)).AsString(),
            colorSuccess: colorMapToken.ColorSuccess,
            colorSuccessActive: colorMapToken.ColorSuccessActive,
            colorSuccessBg: colorMapToken.ColorSuccessBg,
            colorSuccessBgHover: colorMapToken.ColorSuccessBgHover,
            colorSuccessBorder: colorMapToken.ColorSuccessBorder,
            colorSuccessBorderHover: colorMapToken.ColorSuccessBorderHover,
            colorSuccessHover: colorMapToken.ColorSuccessHover,
            colorSuccessText: colorMapToken.ColorSuccessText,
            colorSuccessTextActive: colorMapToken.ColorSuccessTextActive,
            colorSuccessTextHover: colorMapToken.ColorSuccessTextHover,
            colorText: colorMapToken.ColorText,
            colorTextBase: seedToken.ColorTextBase,
            colorTextDescription: colorMapToken.ColorTextTertiary,
            colorTextDisabled: colorMapToken.ColorTextQuaternary,
            colorTextHeading: colorMapToken.ColorText,
            colorTextLabel: colorMapToken.ColorTextSecondary,
            colorTextLightSolid: colorMapToken.ColorWhite,
            colorTextPlaceholder: colorMapToken.ColorTextQuaternary,
            colorTextQuaternary: colorMapToken.ColorTextQuaternary,
            colorTextSecondary: colorMapToken.ColorTextSecondary,
            colorTextTertiary: colorMapToken.ColorTextTertiary,
            colorWarning: colorMapToken.ColorWarning,
            colorWarningActive: colorMapToken.ColorWarningActive,
            colorWarningBg: colorMapToken.ColorWarningBg,
            colorWarningBgHover: colorMapToken.ColorWarningBgHover,
            colorWarningBorder: colorMapToken.ColorWarningBorder,
            colorWarningBorderHover: colorMapToken.ColorWarningBorderHover,
            colorWarningHover: colorMapToken.ColorWarningHover,
            colorWarningOutline: new HEX(colorMapToken.ColorWarningBg).ClampAlpha(new HEX(colorMapToken.ColorBgContainer)).AsString(),
            colorWarningText: colorMapToken.ColorWarningText,
            colorWarningTextActive: colorMapToken.ColorWarningTextActive,
            colorWarningTextHover: colorMapToken.ColorWarningTextHover,
            colorWhite: colorMapToken.ColorWhite,
            controlHeight: seedToken.ControlHeight,
            controlHeightLG: heightMapToken.ControlHeightLG,
            controlHeightSM: heightMapToken.ControlHeightSM,
            controlHeightXS: heightMapToken.ControlHeightXS,
            controlInteractiveSize: seedToken.ControlHeight / 2,
            controlItemBgActive: colorMapToken.ColorPrimaryBg,
            controlItemBgActiveDisabled: colorMapToken.ColorFill,
            controlItemBgActiveHover: colorMapToken.ColorPrimaryBgHover,
            controlItemBgHover: colorMapToken.ColorFillTertiary,
            controlOutline: new HEX(colorMapToken.ColorPrimaryBg).ClampAlpha(new HEX(colorMapToken.ColorBgContainer)).AsString(),
            controlOutlineWidth: seedToken.LineWidth * 2,
            controlPaddingHorizontal: 12,
            controlPaddingHorizontalSM: 8,
            controlTmpOutline: colorMapToken.ColorFillQuaternary,
            cyan: seedToken.Cyan,
            cyan1: colorPalettes.Cyan1,
            cyan10: colorPalettes.Cyan10,
            cyan2: colorPalettes.Cyan2,
            cyan3: colorPalettes.Cyan3,
            cyan4: colorPalettes.Cyan4,
            cyan5: colorPalettes.Cyan5,
            cyan6: colorPalettes.Cyan6,
            cyan7: colorPalettes.Cyan7,
            cyan8: colorPalettes.Cyan8,
            cyan9: colorPalettes.Cyan9,
            fontFamily: seedToken.FontFamily,
            fontFamilyCode: seedToken.FontFamilyCode,
            fontSize: seedToken.FontSize,
            fontSizeHeading1: fontMapToken.FontSizeHeading1,
            fontSizeHeading2: fontMapToken.FontSizeHeading2,
            fontSizeHeading3: fontMapToken.FontSizeHeading3,
            fontSizeHeading4: fontMapToken.FontSizeHeading4,
            fontSizeHeading5: fontMapToken.FontSizeHeading5,
            fontSizeIcon: fontMapToken.FontSizeSM,
            fontSizeLG: fontMapToken.FontSizeLG,
            fontSizeSM: fontMapToken.FontSizeSM,
            fontSizeXL: fontMapToken.FontSizeXL,
            fontWeightStrong: 600,
            geekblue: seedToken.Geekblue,
            geekblue1: colorPalettes.Geekblue1,
            geekblue10: colorPalettes.Geekblue10,
            geekblue2: colorPalettes.Geekblue2,
            geekblue3: colorPalettes.Geekblue3,
            geekblue4: colorPalettes.Geekblue4,
            geekblue5: colorPalettes.Geekblue5,
            geekblue6: colorPalettes.Geekblue6,
            geekblue7: colorPalettes.Geekblue7,
            geekblue8: colorPalettes.Geekblue8,
            geekblue9: colorPalettes.Geekblue9,
            gold: seedToken.Gold,
            gold1: colorPalettes.Gold1,
            gold10: colorPalettes.Gold10,
            gold2: colorPalettes.Gold2,
            gold3: colorPalettes.Gold3,
            gold4: colorPalettes.Gold4,
            gold5: colorPalettes.Gold5,
            gold6: colorPalettes.Gold6,
            gold7: colorPalettes.Gold7,
            gold8: colorPalettes.Gold8,
            gold9: colorPalettes.Gold9,
            green: seedToken.Green,
            green1: colorPalettes.Green1,
            green10: colorPalettes.Green10,
            green2: colorPalettes.Green2,
            green3: colorPalettes.Green3,
            green4: colorPalettes.Green4,
            green5: colorPalettes.Green5,
            green6: colorPalettes.Green6,
            green7: colorPalettes.Green7,
            green8: colorPalettes.Green8,
            green9: colorPalettes.Green9,
            lime: seedToken.Lime,
            lime1: colorPalettes.Lime1,
            lime10: colorPalettes.Lime10,
            lime2: colorPalettes.Lime2,
            lime3: colorPalettes.Lime3,
            lime4: colorPalettes.Lime4,
            lime5: colorPalettes.Lime5,
            lime6: colorPalettes.Lime6,
            lime7: colorPalettes.Lime7,
            lime8: colorPalettes.Lime8,
            lime9: colorPalettes.Lime9,
            lineHeight: fontMapToken.LineHeight,
            lineHeightHeading1: fontMapToken.LineHeightHeading1,
            lineHeightHeading2: fontMapToken.LineHeightHeading2,
            lineHeightHeading3: fontMapToken.LineHeightHeading3,
            lineHeightHeading4: fontMapToken.LineHeightHeading4,
            lineHeightHeading5: fontMapToken.LineHeightHeading5,
            lineHeightLG: fontMapToken.LineHeightLG,
            lineHeightSM: fontMapToken.LineHeightSM,
            lineType: seedToken.LineType,
            lineWidth: seedToken.LineWidth,
            lineWidthBold: commonMapToken.LineWidthBold,
            linkDecoration: "none",
            linkFocusDecoration: "none",
            linkHoverDecoration: "none",
            magenta: seedToken.Magenta,
            magenta1: colorPalettes.Magenta1,
            magenta10: colorPalettes.Magenta10,
            magenta2: colorPalettes.Magenta2,
            magenta3: colorPalettes.Magenta3,
            magenta4: colorPalettes.Magenta4,
            magenta5: colorPalettes.Magenta5,
            magenta6: colorPalettes.Magenta6,
            magenta7: colorPalettes.Magenta7,
            magenta8: colorPalettes.Magenta8,
            magenta9: colorPalettes.Magenta9,
            margin: sizeMapToken.Size,
            marginLG: sizeMapToken.SizeLG,
            marginMD: sizeMapToken.SizeMD,
            marginSM: sizeMapToken.SizeSM,
            marginXL: sizeMapToken.SizeXL,
            marginXS: sizeMapToken.SizeXS,
            marginXXL: sizeMapToken.SizeXXL,
            marginXXS: sizeMapToken.SizeXXS,
            motionBase: seedToken.MotionBase,
            motionDurationFast: commonMapToken.MotionDurationFast,
            motionDurationMid: commonMapToken.MotionDurationMid,
            motionDurationSlow: commonMapToken.MotionDurationSlow,
            motionEaseInBack: seedToken.MotionEaseInBack,
            motionEaseInOut: seedToken.MotionEaseInOut,
            motionEaseInOutCirc: seedToken.MotionEaseInOutCirc,
            motionEaseInQuint: seedToken.MotionEaseInQuint,
            motionEaseOut: seedToken.MotionEaseOut,
            motionEaseOutBack: seedToken.MotionEaseOutBack,
            motionEaseOutCirc: seedToken.MotionEaseOutCirc,
            motionEaseOutQuint: seedToken.MotionEaseOutQuint,
            motionUnit: seedToken.MotionUnit,
            opacityImage: seedToken.OpacityImage,
            opacityLoading: 0.65,
            orange: seedToken.Orange,
            orange1: colorPalettes.Orange1,
            orange10: colorPalettes.Orange10,
            orange2: colorPalettes.Orange2,
            orange3: colorPalettes.Orange3,
            orange4: colorPalettes.Orange4,
            orange5: colorPalettes.Orange5,
            orange6: colorPalettes.Orange6,
            orange7: colorPalettes.Orange7,
            orange8: colorPalettes.Orange8,
            orange9: colorPalettes.Orange9,
            padding: sizeMapToken.Size,
            paddingContentHorizontal: sizeMapToken.SizeMS,
            paddingContentHorizontalLG: sizeMapToken.SizeLG,
            paddingContentHorizontalSM: sizeMapToken.Size,
            paddingContentVertical: sizeMapToken.SizeSM,
            paddingContentVerticalLG: sizeMapToken.SizeMS,
            paddingContentVerticalSM: sizeMapToken.SizeXS,
            paddingLG: sizeMapToken.SizeLG,
            paddingMD: sizeMapToken.SizeMD,
            paddingSM: sizeMapToken.SizeSM,
            paddingXL: sizeMapToken.SizeXL,
            paddingXS: sizeMapToken.SizeXS,
            paddingXXS: sizeMapToken.SizeXXS,
            pink: seedToken.Pink,
            pink1: colorPalettes.Pink1,
            pink10: colorPalettes.Pink10,
            pink2: colorPalettes.Pink2,
            pink3: colorPalettes.Pink3,
            pink4: colorPalettes.Pink4,
            pink5: colorPalettes.Pink5,
            pink6: colorPalettes.Pink6,
            pink7: colorPalettes.Pink7,
            pink8: colorPalettes.Pink8,
            pink9: colorPalettes.Pink9,
            purple: seedToken.Purple,
            purple1: colorPalettes.Purple1,
            purple10: colorPalettes.Purple10,
            purple2: colorPalettes.Purple2,
            purple3: colorPalettes.Purple3,
            purple4: colorPalettes.Purple4,
            purple5: colorPalettes.Purple5,
            purple6: colorPalettes.Purple6,
            purple7: colorPalettes.Purple7,
            purple8: colorPalettes.Purple8,
            purple9: colorPalettes.Purple9,
            red: seedToken.Red,
            red1: colorPalettes.Red1,
            red10: colorPalettes.Red10,
            red2: colorPalettes.Red2,
            red3: colorPalettes.Red3,
            red4: colorPalettes.Red4,
            red5: colorPalettes.Red5,
            red6: colorPalettes.Red6,
            red7: colorPalettes.Red7,
            red8: colorPalettes.Red8,
            red9: colorPalettes.Red9,
            screenLG: screenLG,
            screenLGMax: screenXL - 1,
            screenLGMin: screenLG,
            screenMD: screenMD,
            screenMDMax: screenLG - 1,
            screenMDMin: screenMD,
            screenSM: screenSM,
            screenSMMax: screenMD - 1,
            screenSMMin: screenSM,
            screenXL: screenXL,
            screenXLMax: screenXXL - 1,
            screenXLMin: screenXL,
            screenXS: screenXS,
            screenXSMax: screenSM - 1,
            screenXSMin: screenXS,
            screenXXL: screenXXL,
            screenXXLMin: screenXXL,
            size: sizeMapToken.Size,
            sizeLG: sizeMapToken.SizeLG,
            sizeMD: sizeMapToken.SizeMD,
            sizeMS: sizeMapToken.SizeMS,
            sizePopupArrow: seedToken.SizePopupArrow,
            sizeSM: sizeMapToken.SizeSM,
            sizeStep: seedToken.SizeStep,
            sizeUnit: seedToken.SizeUnit,
            sizeXL: sizeMapToken.SizeXL,
            sizeXS: sizeMapToken.SizeXS,
            sizeXXL: sizeMapToken.SizeXXL,
            sizeXXS: sizeMapToken.SizeXXS,
            volcano: seedToken.Volcano,
            volcano1: colorPalettes.Volcano1,
            volcano10: colorPalettes.Volcano10,
            volcano2: colorPalettes.Volcano2,
            volcano3: colorPalettes.Volcano3,
            volcano4: colorPalettes.Volcano4,
            volcano5: colorPalettes.Volcano5,
            volcano6: colorPalettes.Volcano6,
            volcano7: colorPalettes.Volcano7,
            volcano8: colorPalettes.Volcano8,
            volcano9: colorPalettes.Volcano9,
            wireframe: seedToken.Wireframe,
            yellow: seedToken.Yellow,
            yellow1: colorPalettes.Yellow1,
            yellow10: colorPalettes.Yellow10,
            yellow2: colorPalettes.Yellow2,
            yellow3: colorPalettes.Yellow3,
            yellow4: colorPalettes.Yellow4,
            yellow5: colorPalettes.Yellow5,
            yellow6: colorPalettes.Yellow6,
            yellow7: colorPalettes.Yellow7,
            yellow8: colorPalettes.Yellow8,
            yellow9: colorPalettes.Yellow9,
            zIndexBase: seedToken.ZIndexBase,
            zIndexPopupBase: seedToken.ZIndexPopupBase)
    {
    }

    // FIXME: component box-shadow, should be removed
    internal static string BoxShadowPopoverArrow => "2px 2px 5px rgba(0, 0, 0, 0.05)";
    internal static string BoxShadowCard => "0 1px 2px -2px rgba(0, 0, 0, 0.16), 0 3px 6px 0 rgba(0, 0, 0, 0.12), 0 5px 12px 4px rgba(0, 0, 0, 0.09)";
    internal static string BoxShadowDrawerRight => "-6px 0 16px 0 rgba(0, 0, 0, 0.08), -3px 0 6px -4px rgba(0, 0, 0, 0.12), -9px 0 28px 8px rgba(0, 0, 0, 0.05)";
    internal static string BoxShadowDrawerLeft => "6px 0 16px 0 rgba(0, 0, 0, 0.08), 3px 0 6px -4px rgba(0, 0, 0, 0.12), 9px 0 28px 8px rgba(0, 0, 0, 0.05)";
    internal static string BoxShadowDrawerUp => "0 6px 16px 0 rgba(0, 0, 0, 0.08), 0 3px 6px -4px rgba(0, 0, 0, 0.12), 0 9px 28px 8px rgba(0, 0, 0, 0.05)";
    internal static string BoxShadowDrawerDown => "0 -6px 16px 0 rgba(0, 0, 0, 0.08), 0 -3px 6px -4px rgba(0, 0, 0, 0.12), 0 -9px 28px 8px rgba(0, 0, 0, 0.05)";
    internal static string BoxShadowTabsOverflowLeft => "inset 10px 0 8px -8px rgba(0, 0, 0, 0.08)";
    internal static string BoxShadowTabsOverflowRight => "inset -10px 0 8px -8px rgba(0, 0, 0, 0.08)";
    internal static string BoxShadowTabsOverflowTop => "inset 0 10px 8px -8px rgba(0, 0, 0, 0.08)";
    internal static string BoxShadowTabsOverflowBottom => "inset 0 -10px 8px -8px rgba(0, 0, 0, 0.08)";
}
