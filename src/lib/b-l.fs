\ lib/b-l.fs

\ This file is part of Sin Forth.

\ This file adds `bl` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260211.
\ See change log at the end of the file.

\ ==============================================================

require c-constant.fs \ `cconstant`

get-order get-current

target-definitions

32 cconstant bl

  \ doc{
  \
  \ bl ( -- c ) "b-l"
  \
  \ A `cconstant`. _c_ is the character value for a space.
  \
  \ Because space is used throughout Forth as the standard
  \ delimiter, ``bl`` is the only way a program has to find and
  \ use the character value of a space.
  \
  \ See also: `space`, `emit`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
