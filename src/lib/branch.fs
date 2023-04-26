\ lib/branch.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1334+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

get-order get-current

compiler-definitions

compiler{ synonym branch jp, }

  \ doc{
  \
  \ branch
  \   Compilation: ( dest -- )
  \   Run-time:    ( -- )
  \
  \ Compilation: compile the Z80 ``jp`` instruction to jump
  \ unconditionally to _dest_.
  \
  \ Run-time: branch unconditionally to _dest_.
  \
  \ NOTE: ``branch`` is implemented as an alias of `jp,`.
  \
  \ // XXX TODO
  \ // See also: `?branch`, `0branch`, `-branch`, `+branch`.
  \
  \ See also: `0branch`.
  \
  \ }doc

set-current set-order
