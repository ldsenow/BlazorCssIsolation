# BlazorCssIsolation

The Blazor App puts a ConfigProvider in App.razor so it can cascade the `Theme` down to all child `Components`.

The default `Primary` color is `#1890ff`. The App demonstrates that it can modify the default `Primary` color to `green`. 

You will see 2 buttons when you launch the app. One is `green` border and one is `red` border.

Since the App changes the default `Primary` color to `green` and the `Button` sets the `--ant-button-primary-border-color: var(--ant-primary);` as the border color, so all `Buttons`' default border color will be `green` not `#1890ff` if we change the `ConfigProvider`'s `Primary` value.

There is also a `red` border `Button` which is under a nested `ConfigProvider` that the `ButtonPrimaryBorderColor` is set to `red`. It overrides the App's `ConfigProvider`'s settings. This demonstrates that we can also make changes within a nested scope.

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
- is a simple component has an isolated css (`Button.razor.css`) which contains `Button` design tokens.

#

## Pros
- css styles are scoped
- css styles can be cached
- different versions can co-exist
- modify only what you want

## Cons
- not easy to change the css variable prefix and maintain the variables (ideally can generate those isolated css files e.g. from a pre-processor or `'Style Dictionary'`)