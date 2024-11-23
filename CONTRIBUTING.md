# Contributing to TheBereftSouls

## Table of Contents

- [I Have a Question](#i-have-a-question)
- [I Want To Contribute](#i-want-to-contribute)
  - [Reporting Bugs](#reporting-bugs)
  - [Suggesting Enhancements](#suggesting-enhancements)
  - [Your First Code Contribution](#your-first-code-contribution)
- [Style Guides](#style-guides)
  - [Code Formatting](#code-formatting)
  - [Commit Messages](#commit-messages)
- [Community](#community)

## I Have a Question

1. There's a `#questions` channel in the
   [Discord server](https://discord.com/invite/nYJfz3jgQy).
   Feel free to search for similar existing questions or ask your own in it!
2. Feel free to search through the
   [existing issues](https://github.com/bromeex/TheBereftSouls/issues)
   for a potential answer.

## I Want To Contribute

> [!NOTE]
> You have complete right over all the code you contribute and can make a
> proposal for removal if you wish to.

### Reporting Bugs

> [!NOTE]
> Since this is a big modpack, it's possible that the bug is related to a
> specific mod, rather than the modpack itself

1. Make sure to use the latest version of the .NET runtime and .NET SDK.
2. Make sure to check out the
   [existing bug reports](https://github.com/bromeex/TheBereftSouls/labels/bug)
   to verify if your bug hasn't already been posted.
3. Once that's checked out and your bug is unique then make sure to post an issue
   under the [Issues](https://github.com/bromeex/TheBereftSouls/issues) tab.
4. The Issue you post should contain:

- Description of the bug (what happens)
- What should happen
- Information about your OS (Windows, Linux, MacOS, etc.) and their version.
- A stack trace and/or a log file.
- (If possible): ways to reproduce the bug.

### Your First Code Contribution

1. You can contribute for existing issues/pull requests by checking the
   [good first issue](https://github.com/bromeex/TheBereftSouls/labels/good%20first%20issue)
   label.
2. Feel free to communicate with other contributors on the
   [Discord server](https://discord.com/invite/nYJfz3jgQy)
   for more opportunities and ideas for your first contribution!
3. The quality is what matters, not the quantity. Feel free to create an issue
   with your suggestion if you find it valuable.

### Suggesting Enhancements

Before creating your suggestion:

1. Make sure you're on the latest version of the `main` branch of the repository.
2. Search through the [Issues](https://github.com/bromeex/TheBereftSouls/issues)
   to see if it's already discussed.
3. Evaluate if your feature is useful for most of/everyone using this mod and
   not just a small niche of players.

## Style Guides

### Code Formatting

The formatting is achieved via [CSharpier](https://csharpier.com/) with the
[`.csharpierrc.yaml`](./.csharpierrc.yaml) configuration _(for more information,
check: <https://csharpier.com/docs/Configuration>)_.

> [!NOTE]
> Make sure to install `csharpier`. You can do this with NuGet like so:
>
> ```sh
> dotnet tool install csharpier
> ```
>
> _For more information: <https://csharpier.com/docs/About>_

### Commit Messages

`.git/COMMIT_EDITMSG`:

```txt
Title (descriptive and concise - max: 72 characers)

Additional details about the commit. You can add links for sources for
example[1].

Or just a list of links with this explanation:
- https://example.com
- https://example.com
- https://example.com

NOTE: Every line from the description should be at most 80 characters long.

[1]: https://example.com

# Please enter the commit message for your changes. Lines starting
# with '#' will be ignored, and an empty message aborts the commit.
#
# On branch main
# Your branch is up to date with 'origin/main'.
#
# Changes to be committed:
# *<YOUR FILE CHANGES>*
```

## Community

Feel free to join the community on
[Discord](https://discord.com/invite/nYJfz3jgQy) as it's very active!
