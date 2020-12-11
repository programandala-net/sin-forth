\ lib/bracket-tick.fs

\ This file is part of Sin Forth.

\ This file adds `[']` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111816.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/lib/tick.fs

get-order get-current

compiler-definitions

compiler-wordlist >order
synonym ['] '
previous

  \ doc{
  \
  \ [']  Compilation: ( "name" -- dea ) "bracket-ttick"
  \
  \ Parse _name_ and return its _dea_ (dictionary entry address).
  \ ``[']`` is a synonym of `'`, to facilitate the conversion of
  \ standard Forth programs. The actual meaning of _dea_ depends on
  \ the definer word used to create _name_. See `'` for details.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
