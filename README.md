# BlazorCssIsolation

## ConfigProvider component
- cascades `Theme` to child components
- can be nested with another ConfigProvider
- can override the default `Theme` variables

## ConfigProvider.razor.css
- contains base variables

## Theme
- contains `DesignTokens` of `Base` and `Components'` props for the app to customize

## DesignTokens.cs
- uses reflection to generate inline css style variables overrides if any props aren't null
- is intended to use in all `Components`

## Button
- is a component has an isolated css (`Button.razor.css`) which contains `Button` design tokens and also uses `Base` design tokens