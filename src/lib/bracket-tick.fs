\ lib/bracket-tick.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
